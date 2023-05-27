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
    
    /// <summary>
    /// This method is used to get all ads
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _adService.GetAllAsync());
    }
    
    /// <summary>
    /// This method is used to pagination and filter of ads
    /// </summary>
    /// <param name="requestModel"></param>
    /// <returns></returns>
    [HttpPost("getAdsByFilter")]
    public async Task<IActionResult> GetAdsByFilterAsync(AdFilterRequestModel requestModel)
    {
        return CreateActionResult(await _adService.GetAdsByFilterAsync(requestModel));
    }

    /// <summary>
    /// This method is used to get ad by id
    /// </summary>
    /// <returns></returns>
    [HttpGet("getById")]
    public async Task<IActionResult> GetById(Guid id)
    {
        return CreateActionResult(await _adService.GetByIdAsync(id));
    }
    
    /// <summary>
    /// This method is used to add new ad.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task<IActionResult> Add(AdModel model)
    {
        return CreateActionResult(await _adService.AddAsync(model));
    }
}