using Core.Entities;
using Core.Models;
using Core.Responses;

namespace Core.Services;

public interface IPetIdentityService : IGenericService<PetIdentity, PetIdentityModel>
{
    Task<Response<List<PetIdentityModel>>> GetPetIdentitiesByUserIdAsync(string userId);
}