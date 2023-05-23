using Peticom.Core.Entities;
using Peticom.Core.Models.PetDisease;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IPetDiseaseService : IGenericService<PetDisease, PetDiseaseModel>
{
    public Task<List<PetDiseaseModel>> GetPetDiseasesByPetIdAsync(Guid petId);
}