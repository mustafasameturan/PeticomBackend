using Peticom.Core.Entities;

namespace Peticom.Core.Repositories;

public interface IPetIdentityRepository : IGenericRepository<PetIdentity>
{
    Task<List<PetIdentity>> GetPetIdentitiesByUserIdAsync(string userId);
}