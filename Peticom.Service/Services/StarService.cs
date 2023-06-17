using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Models.Star;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class StarService : GenericService<Star, StarModel>, IStarService
{
    private readonly IStarRepository _starRepository;
    private readonly IMapper _mapper;
    
    public StarService(IUnitOfWork unitOfWork, IGenericRepository<Star> repository, IMapper mapper,
        IStarRepository starRepository) : base(unitOfWork, repository, mapper)
    {
        _starRepository = starRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// This method is get stars by ad id.
    /// </summary>
    /// <param name="adId"></param>
    /// <returns></returns>
    public async Task<Response<List<StarModel>>> GetStarsByAdIdAsync(Guid adId)
    {
        var stars = await _starRepository.GetStarsByAdIdAsync(adId);

        if (stars.Count == 0)
        {
            return Response<List<StarModel>>.Fail("Stars not found.", 404, true);
        }
        
        var mappedStars = _mapper.Map<List<StarModel>>(stars);

        return Response<List<StarModel>>.Success(mappedStars, 200);
    }

    /// <summary>
    /// This method is responsible for get star by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<StarModel>> GetStarsByUserIdAsync(string userId, Guid adId)
    {
        var star = await _starRepository
            .Where(s => s.UserId == userId)
            .Where(a => a.AdId == adId).FirstOrDefaultAsync();

        if (star is null)
        {
            return Response<StarModel>.Fail("Stars not found.", 404, true);
        }
        
        var mappedStar = _mapper.Map<StarModel>(star);

        return Response<StarModel>.Success(mappedStar, 200);
    }

    /// <summary>
    /// This method calculate average star by ad id.
    /// </summary>
    /// <param name="adId"></param>
    /// <returns></returns>
    public async Task<Response<double>> CalculateStarAverageByAdIdAsync(Guid adId)
    {
        var stars = await _starRepository.Where(s => s.AdId == adId).ToListAsync();;
        double total = 0.0;
        double result = 0.0;

        if (stars.Count == 0)
        {
            return Response<double>.Success(0.0, 200);
        }
        
        foreach (var star in stars)
        {
            total += star.StarCount;
        }

        result = total / stars.Count;
            
        return Response<double>.Success(result, 200);
    }
}