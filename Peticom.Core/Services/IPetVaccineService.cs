using Peticom.Core.Entities;
using Peticom.Core.Models.PetVaccine;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IPetVaccineService : IGenericService<PetVaccine, PetVaccineModel> 
{
    public Task<List<PetVaccineModel>> GetPetVaccinesByPetIdAsync(Guid petId);
}