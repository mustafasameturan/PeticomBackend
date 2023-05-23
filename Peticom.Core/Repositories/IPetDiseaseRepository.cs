using Peticom.Core.Entities;

namespace Peticom.Core.Repositories;

public interface IPetDiseaseRepository : IGenericRepository<PetDisease>
{
    public Task<List<PetDisease>> GetPetDiseasesByPetIdAsync(Guid petId);
}