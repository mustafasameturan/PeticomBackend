using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

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
}