using Peticom.Core.Entities;

namespace Peticom.Core.Repositories;

public interface IPetVaccineRepository : IGenericRepository<PetVaccine>
{
    public Task<List<PetVaccine>> GetPetVaccinesByPetIdAsync(Guid petId);
}