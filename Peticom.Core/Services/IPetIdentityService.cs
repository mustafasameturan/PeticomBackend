using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IPetIdentityService : IGenericService<PetIdentity, PetIdentityModel>
{
    Task<Response<List<PetFullIdentityModel>>> GetPetFullIdentityByUserIdAsync(string userId);
    Task<Response<List<PetIdentitySelectListModel>>> GetPetIdentitySelectListAsync(string userId);
    Task<Response<bool>> IsPeticomerHavePetAsync(string userId);
}