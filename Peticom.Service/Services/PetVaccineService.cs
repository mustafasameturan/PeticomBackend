using AutoMapper;
using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Models.PetVaccine;
using Peticom.Core.Repositories;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;

namespace Peticom.Service.Services;

public class PetVaccineService : GenericService<PetVaccine, PetVaccineModel>, IPetVaccineService
{
    private readonly IPetVaccineRepository _petVaccineRepository;
    private readonly IMapper _mapper;
    
    public PetVaccineService(IUnitOfWork unitOfWork, IGenericRepository<PetVaccine> repository, IPetVaccineRepository petVaccineRepository, IMapper mapper) : base(unitOfWork, repository, mapper)
    {
        _petVaccineRepository = petVaccineRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// This method returns pet vaccines by pet id for server.
    /// </summary>
    /// <param name="petId"></param>
    /// <returns></returns>
    public async Task<List<PetVaccineModel>> GetPetVaccinesByPetIdAsync(Guid petId)
    {
        var petVaccines = await _petVaccineRepository.GetPetVaccinesByPetIdAsync(petId);

        var mappedPetVaccines = _mapper.Map<List<PetVaccineModel>>(petVaccines);

        return mappedPetVaccines;
    }
}