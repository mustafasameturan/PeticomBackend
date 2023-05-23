using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/petIdentities")]
[ApiController]
public class PetIdentitiesController : BaseController
{
    private readonly IPetIdentityService _petIdentityService;

    public PetIdentitiesController(IPetIdentityService petIdentityService)
    {
        _petIdentityService = petIdentityService;
    }

    /// <summary>
    /// This method is used to get all entities
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _petIdentityService.GetAllAsync());
    }
    
    [HttpGet("getFullIdentityByUserId")]
    public async Task<IActionResult> GetFullIdentityByUserId(string userId)
    {
        return CreateActionResult(await _petIdentityService.GetPetFullIdentityByUserIdAsync(userId));
    }
}