using AutoMapper;
using Peticom.Core.Entities;
using Peticom.Core.Models.PeticomerHome;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class PeticomerHomeService : GenericService<PeticomerHome, PeticomerHomeModel>, IPeticomerHomeService
{
    private readonly IPeticomerHomeRepository _peticomerHomeRepository;
    private readonly IMapper _mapper;
    
    public PeticomerHomeService(IUnitOfWork unitOfWork, IGenericRepository<PeticomerHome> repository, IMapper mapper,
        IPeticomerHomeRepository peticomerHomeRepository) : base(unitOfWork, repository, mapper)
    {
        _peticomerHomeRepository = peticomerHomeRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// This method get peticomer home by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<List<PeticomerHomeModel>>> GetPeticomerHomeByUserIdAsync(string userId)
    {
        var peticomerHomes = await _peticomerHomeRepository.GetPeticomerHomeByUserIdAsync(userId);

        if (peticomerHomes.Count == 0)
        {
            return Response<List<PeticomerHomeModel>>.Fail("Peticomer homes not found.", 404, true);
        }
        
        var mappedPeticomerHomes = _mapper.Map<List<PeticomerHomeModel>>(peticomerHomes);

        return Response<List<PeticomerHomeModel>>.Success(mappedPeticomerHomes, 200);
    }
}