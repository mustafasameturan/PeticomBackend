using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class AdService : GenericService<Ad, AdModel>, IAdService
{
    
    private readonly IMapper _mapper;
    private readonly IAdRepository _adRepository;
    public AdService(IUnitOfWork unitOfWork, IGenericRepository<Ad> repository, IMapper mapper, IAdRepository adRepository) : base(unitOfWork, repository, mapper)
    {
        _mapper = mapper;
        _adRepository = adRepository;
    }

    public async Task<Response<AdFilterResponseModel>> GetAdsByFilterAsync(AdFilterRequestModel requestModel)
    {
        // Öncelikle gerekli verileri alır
        var ads = await _adRepository.GetAll().ToListAsync();

        // Arama terimine göre filtreleme yapar (büyük küçük harf duyarsız)
        if (!string.IsNullOrEmpty(requestModel.Search))
        {
            ads = ads.Where(ad => ad.Slogan.IndexOf(requestModel.Search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        
        // Toplam kayıt sayısını alır
        var recordsTotal = ads.Count;

        // Sayfalama işlemini gerçekleştirir
        ads = ads.Skip(requestModel.Start).Take(requestModel.Limit).ToList();

        var adModelList = ads.Select(a => new AdModel
        {   
            UserId = a.UserId,
            Slogan = a.Slogan,
            About = a.About,
            Price = a.Price
        }).ToList();

        // AdFilterResponseModel'i doldurur
        var responseModel = new AdFilterResponseModel(adModelList, recordsTotal, adModelList.Count);  

        return Response<AdFilterResponseModel>.Success(responseModel, 200);
    }

}