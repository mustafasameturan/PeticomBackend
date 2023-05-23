using Peticom.Core.Entities;

namespace Peticom.Core.Repositories;

public interface IPetIdentityRepository : IGenericRepository<PetIdentity>
{
    public Task<List<PetIdentity>> GetPetIdentityByUserIdAsync(string userId);
}