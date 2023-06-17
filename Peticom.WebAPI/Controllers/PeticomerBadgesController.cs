using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.PeticomerBadge;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/peticomerBadges")]
[ApiController]
public class PeticomerBadgesController : BaseController
{
    private readonly IPeticomerBadgeService _peticomerBadgeService;

    public PeticomerBadgesController(IPeticomerBadgeService peticomerBadgeService)
    {
        _peticomerBadgeService = peticomerBadgeService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    { 
        return  CreateActionResult(await _peticomerBadgeService.GetAllAsync());
    }

    [HttpGet("getPeticomerBadgeByUserId")]
    public async Task<IActionResult> GetPeticomerBadgeByUserIdAsync(string userId)
    {
        return CreateActionResult(await _peticomerBadgeService.GetPeticomerBadgeByUserIdAsync(userId));
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddPeticomerBadge(PeticomerBadgeModel peticomerBadgeModel)
    {
        return CreateActionResult(await _peticomerBadgeService.AddAsync(peticomerBadgeModel));
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdatePeticomerBadge(PeticomerBadgeModel peticomerBadgeModel)
    {
        return CreateActionResult(await _peticomerBadgeService.UpdateAsync(peticomerBadgeModel));
    }
}