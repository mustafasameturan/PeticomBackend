using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

public class AdsController : BaseController
{
    private readonly IAdService _adService;

    public AdsController(IAdService adService)
    {
        _adService = adService;
    }
    
    /// <summary>
    /// This method is used to get all entities
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _adService.GetAllAsync());
    }
    
    /// <summary>
    /// This method is used to get entity by id
    /// </summary>
    /// <returns></returns>
    [HttpGet("getById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return CreateActionResult(await _adService.GetByIdAsync(id));
    }

    [HttpPost("add")]
    public async Task<IActionResult> Add(AdModel model)
    {
        return CreateActionResult(await _adService.AddAsync(model));
    }
}