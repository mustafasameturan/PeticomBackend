using AutoMapper;
using Business.Exceptions;
using Core.Entities;
using Core.Models;
using Core.Repositories;
using Core.Responses;
using Core.Services;
using Core.UnitOfWorks;

namespace Business.Services;

public class PetIdentityService : GenericService<PetIdentity, PetIdentityModel>, IPetIdentityService
{

    private readonly IPetIdentityRepository _petIdentityRepository;
    private readonly IMapper _mapper;
    
    public PetIdentityService(IUnitOfWork unitOfWork, IGenericRepository<PetIdentity> repository, IPetIdentityRepository petIdentityRepository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
        _petIdentityRepository = petIdentityRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// This method returns pet identity by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<List<PetIdentityModel>>> GetPetIdentitiesByUserIdAsync(string userId)
    {
        var petIdentities = await _petIdentityRepository.GetPetIdentitiesByUserIdAsync(userId);
        
        if (petIdentities == null)
        {
            throw new NotFoundException("Pet identity not found.");
        }

        var petIdentitiesModel = _mapper.Map<List<PetIdentityModel>>(petIdentities);
        
        return Response<List<PetIdentityModel>>.Success(petIdentitiesModel, 200);
    }
}