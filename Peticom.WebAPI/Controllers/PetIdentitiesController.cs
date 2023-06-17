using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models;
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

    [HttpGet("petIdentitiesSelectListByUserId")]
    public async Task<IActionResult> GetPetIdentitiesSelectListByUserId(string userId)
    {
        return CreateActionResult(await _petIdentityService.GetPetIdentitySelectListAsync(userId));
    }

    [HttpGet("getFullIdentityByUserId")]
    public async Task<IActionResult> GetFullIdentityByUserId(string userId)
    {
        return CreateActionResult(await _petIdentityService.GetPetFullIdentityByUserIdAsync(userId));
    }
    
       
    [HttpGet("isPeticomerHavePet")]
    public async Task<IActionResult> IsPeticomerHavePet(string userId)
    {
        return CreateActionResult(await _petIdentityService.IsPeticomerHavePetAsync(userId));
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] PetIdentityModel model)
    {
        return CreateActionResult(await _petIdentityService.AddAsync(model));
    }
}