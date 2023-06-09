using Microsoft.AspNetCore.Identity;
using Peticom.Core.Models;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IRoleService
{
    Task<List<string>> GetAllAsync();
    Task<Response<IdentityRole>> GetRoleByName(string roleName);
    Task<Response<NoDataModel>> CreateRoleAsync(string roleName);
}