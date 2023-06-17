using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;
using Peticom.Service.Exceptions;

namespace Peticom.Service.Services;

public class PetIdentityService : GenericService<PetIdentity, PetIdentityModel>, IPetIdentityService
{
    private readonly IPetIdentityRepository _petIdentityRepository;
    private readonly IPetDiseaseService _petDiseaseService;
    private readonly IPetVaccineService _petVaccineService;
    private readonly IMapper _mapper;
    
    public PetIdentityService(IUnitOfWork unitOfWork, IGenericRepository<PetIdentity> repository, IPetIdentityRepository petIdentityRepository, IMapper mapper,
            IPetDiseaseService petDiseaseService, IPetVaccineService petVaccineService) : base(unitOfWork, repository, mapper)
    {
        _petIdentityRepository = petIdentityRepository;
        _petDiseaseService = petDiseaseService;
        _petVaccineService = petVaccineService;
        _mapper = mapper;
    }

    /// <summary>
    /// This method returns pet identity by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<Response<List<PetIdentityModel>>> GetPetIdentitiesByUserIdAsync(string userId)
    {
        var petIdentities = await _petIdentityRepository
            .Where(i => i.UserId == userId)
            .ToListAsync();
        
        if (petIdentities == null)
        {
            throw new NotFoundException("Pet identity not found.");
        }

        var petIdentitiesModel = _mapper.Map<List<PetIdentityModel>>(petIdentities);
        
        return Response<List<PetIdentityModel>>.Success(petIdentitiesModel, 200);
    }

    /// <summary>
    /// This method returns pet full identity by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<Response<List<PetFullIdentityModel>>> GetPetFullIdentityByUserIdAsync(string userId)
    {
        List<PetFullIdentityModel> petFullIdentitiesModel = new List<PetFullIdentityModel>();
        var petIdentities = await _petIdentityRepository.GetPetIdentityByUserIdAsync(userId);

        if (petIdentities.Count == 0)
        {
            return Response<List<PetFullIdentityModel>>.Fail("Pet identity not found.", 404, true);
        }

        foreach (var identity in petIdentities)
        {
            var petFullIdentityModel = new PetFullIdentityModel
            {
                PetId = identity.Id,
                UserId = identity.UserId,
                Name = identity.Name,
                PetBreed = identity.PetBreed,
                Type = identity.Type,
                Color = identity.Color,
                BirthDate = identity.BirthDate,
                Gender = identity.Gender,
                Food = identity.Food,
                PetLitter = identity.PetLitter,
                LastInsDate = identity.LastInsDate,
                PetDiseases = await _petDiseaseService.GetPetDiseasesByPetIdAsync(identity.Id),
                PetVaccines = await _petVaccineService.GetPetVaccinesByPetIdAsync(identity.Id)
            };

            petFullIdentitiesModel.Add(petFullIdentityModel);
        }
        
        return Response<List<PetFullIdentityModel>>.Success(petFullIdentitiesModel, 200);
    }
    
    /// <summary>
    /// This method get pet identities for select list.
    /// </summary>
    /// <returns></returns>
    public async Task<Response<List<PetIdentitySelectListModel>>> GetPetIdentitySelectListAsync(string userId)
    {
        var petIdentities = await _petIdentityRepository.GetPetIdentityByUserIdAsync(userId);

        var mappedPetIdentities = _mapper.Map<List<PetIdentitySelectListModel>>(petIdentities);

        return Response<List<PetIdentitySelectListModel>>.Success(mappedPetIdentities, 200);
    }

    /// <summary>
    /// This method return peticomer pet statusİ
    /// </summary>
    /// <returns></returns>
    public async Task<Response<bool>> IsPeticomerHavePetAsync(string userId)
    {
        var petIdentity = await _petIdentityRepository.Where(p => p.UserId == userId).ToListAsync();

        if (petIdentity.Count == 0)
        {
            return Response<bool>.Success(false, 200);
        }
        
        return Response<bool>.Success(true, 200);
    }
}