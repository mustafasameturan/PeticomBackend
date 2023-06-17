using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.Star;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/stars")]
[ApiController]
public class StarsController : BaseController
{
    private readonly IStarService _starService;
    
    public StarsController(IStarService starService)
    {
        _starService = starService;
    }
    
    /// <summary>
    /// This method is get all stars.
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _starService.GetAllAsync());
    }
    
    /// <summary>
    /// This method is get star by ad id.
    /// </summary>
    /// <param name="adId"></param>
    /// <returns></returns>
    [HttpGet("getStarsByAdId")]
    public async Task<IActionResult> GetStarsByAdId(Guid adId)
    {
        return CreateActionResult(await _starService.GetStarsByAdIdAsync(adId));
    }
    
    /// <summary>
    /// This method is responsible for get star by user id. 
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("getStarsByUserIdAndAdId")]
    public async Task<IActionResult> GetStarsByUserId(string userId, Guid adId)
    {
        return CreateActionResult(await _starService.GetStarsByUserIdAsync(userId, adId));
    }
    
    /// <summary>
    /// This method calculate star average by ad id.
    /// </summary>
    /// <param name="adId"></param>
    /// <returns></returns>
    [HttpGet("calculateStarAverageByAdId")]
    public async Task<IActionResult> CalculateStarAverageByAdId(Guid adId)
    {
        return CreateActionResult(await _starService.CalculateStarAverageByAdIdAsync(adId));
    }

    /// <summary>
    /// This method is add star.
    /// </summary>
    /// <param name="starModel"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task<IActionResult> AddStar(StarModel starModel)
    {
        return CreateActionResult(await _starService.AddAsync(starModel));
    }
}