using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/advertisements")]
[ApiController]
public class AdsController : BaseController
{
    private readonly IAdService _adService;

    public AdsController(IAdService adService)
    {
        _adService = adService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _adService.GetAllAsync());
    }
    
    [HttpPost("getAdsByFilter")]
    public async Task<IActionResult> GetAdsByFilterAsync(AdFilterRequestModel requestModel)
    {
        return CreateActionResult(await _adService.GetAdsByFilterAsync(requestModel));
    }

    [HttpGet("getById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return CreateActionResult(await _adService.GetByIdAsync(id));
    }
    
    [HttpGet("getAdsByUserId")]
    public async Task<IActionResult> GetAdsByUserId(string userId)
    {
        return CreateActionResult(await _adService.GetAdsByUserIdAsync(userId));
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> Add(AdModel model)
    {
        return CreateActionResult(await _adService.AddAsync(model));
    }
    
    [HttpDelete("delete")]
    public async Task<IActionResult> Delete(Guid id)
    {
        return CreateActionResult(await _adService.RemoveAsync(id));
    }
}