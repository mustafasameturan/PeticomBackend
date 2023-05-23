using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Models.PetDisease;
using Peticom.Core.Repositories;
using Peticom.Core.Responses;
using Peticom.Core.Services;
using Peticom.Core.UnitOfWorks;
using Peticom.Service.Exceptions;

namespace Peticom.Service.Services;

public class PetDiseaseService : GenericService<PetDisease, PetDiseaseModel>, IPetDiseaseService
{
    private readonly IMapper _mapper;
    private readonly IPetDiseaseRepository _petDiseaseRepository;
    
    public PetDiseaseService(IUnitOfWork unitOfWork, IGenericRepository<PetDisease> repository, IMapper mapper, IPetDiseaseRepository petDiseaseRepository) : base(unitOfWork, repository, mapper)
    {
        _mapper = mapper;
        _petDiseaseRepository = petDiseaseRepository;
    }

    /// <summary>
    /// This method returns pet diseases by pet id for server.
    /// </summary>
    /// <param name="petId"></param>
    /// <returns></returns>
    public async Task<List<PetDiseaseModel>> GetPetDiseasesByPetIdAsync(Guid petId)
    {
        var petDiseases = await _petDiseaseRepository
            .Where(d => d.PetId == petId)
            .ToListAsync();
        
        var mappedPetDiseases = _mapper.Map<List<PetDiseaseModel>>(petDiseases);

        return mappedPetDiseases;
    }
}