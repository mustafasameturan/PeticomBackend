using Core.Entities;
using Core.Models;

namespace Core.Repositories;

public interface IPetIdentityRepository : IGenericRepository<PetIdentity>
{
    Task<List<PetIdentity>> GetPetIdentitiesByUserIdAsync(string userId);
}