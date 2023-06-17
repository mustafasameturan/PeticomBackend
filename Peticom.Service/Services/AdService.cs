using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;
using Peticom.Service.Constants;

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
        var ads = await _adRepository.GetAllWithStarsAsync();
        int adsCount = ads.Count;

        // Arama terimine göre filtreleme yapar (büyük küçük harf duyarsız)
        if (!string.IsNullOrEmpty(requestModel.Search))
        {
            ads = ads.Where(ad => ad.Slogan.IndexOf(requestModel.Search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }

        if (requestModel.CityId != -1)
        {
            ads = ads.Where(ad => ad.CityId == requestModel.CityId).ToList();
        }

        if (requestModel.Order != -1)
        {
            switch (requestModel.Order)
            {
                case 1:
                    ads = ads.OrderBy(a => a.Price).ToList();
                    break;
                case 2:
                    ads = ads.OrderByDescending(a => a.Price).ToList();
                    break;
                case 3:
                    ads = ads.OrderByDescending(a => a.CreatedDate).ToList();
                    break;
                case 4:
                    ads = ads.OrderByDescending(a => a.Stars.Any() ? a.Stars.Average(s => s.StarCount) : 0).ToList();
                    break;
            }
        }

        if (requestModel.Type != null)
        {
            ads = ads.Where(a => a.PetType == requestModel.Type).ToList();
        }
        
        // Toplam kayıt sayısını alır
        var recordsTotal = adsCount;

        // Sayfalama işlemini gerçekleştirir
        ads = ads.Skip(requestModel.Start).Take(requestModel.Limit).ToList();

        var adModelList = ads.Select(a => new AdModel
        {   
            Id = a.Id,
            UserId = a.UserId,
            CityId = a.CityId,
            Slogan = a.Slogan,
            About = a.About,
            Price = a.Price,
            PetType = a.PetType,
            Stars = a.Stars,
            CreatedDate = a.CreatedDate
        }).ToList();

        // AdFilterResponseModel'i doldurur
        var responseModel = new AdFilterResponseModel(adModelList, recordsTotal, adModelList.Count);  

        return Response<AdFilterResponseModel>.Success(responseModel, 200);
    }

    /// <summary>
    /// This method get ads by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<List<AdModel>>> GetAdsByUserIdAsync(string userId)
    {
        var ads = await _adRepository.Where(a => a.UserId == userId).ToListAsync();

        if (ads.Count == 0)
        {
            return Response<List<AdModel>>.Fail(Messages.AD_NOT_FOUND, 404, true);
        }
        
        return Response<List<AdModel>>.Success(_mapper.Map<List<AdModel>>(ads), 200);
    }
}