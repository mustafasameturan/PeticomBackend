using AutoMapper;
using Peticom.Core.Entities;
using Peticom.Core.Models.PeticomerBadge;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class PeticomerBadgeService : GenericService<PeticomerBadge, PeticomerBadgeModel>, IPeticomerBadgeService
{
    private readonly IPeticomerBadgeRepository _peticomerBadgeRepository;
    private readonly IMapper _mapper;
    
    public PeticomerBadgeService(IUnitOfWork unitOfWork, IGenericRepository<PeticomerBadge> repository, IMapper mapper,
        IPeticomerBadgeRepository peticomerBadgeRepository) : base(unitOfWork, repository, mapper)
    {
        _peticomerBadgeRepository = peticomerBadgeRepository;
        _mapper = mapper;
    }


    /// <summary>
    /// This method get all peticomer badge by peticomer id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<List<PeticomerBadgeModel>>> GetPeticomerBadgeByUserIdAsync(string userId)
    {
        var peticomerBadges = await _peticomerBadgeRepository.GetPeticomerBadgeByUserIdAsync(userId);

        if (peticomerBadges.Count == 0)
        {
            return Response<List<PeticomerBadgeModel>>.Fail("Peticomer badge not found.", 404, true);
        }
        
        var mappedPeticomerBadges = _mapper.Map<List<PeticomerBadgeModel>>(peticomerBadges);

        return Response<List<PeticomerBadgeModel>>.Success(mappedPeticomerBadges, 200);
    }
}