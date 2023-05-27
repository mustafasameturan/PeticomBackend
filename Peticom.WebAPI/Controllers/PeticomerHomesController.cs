using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.PeticomerHome;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/peticomerHomes")]
[ApiController]
public class PeticomerHomesController : BaseController
{
    private readonly IPeticomerHomeService _peticomerHomeService;

    public PeticomerHomesController(IPeticomerHomeService peticomerHomeService)
    {
        _peticomerHomeService = peticomerHomeService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _peticomerHomeService.GetAllAsync());
    }
    
    [HttpGet("getPeticomerHomeByUserId")]
    public async Task<IActionResult> GetPeticomerHomeByUserId(string userId)
    {
        return CreateActionResult(await _peticomerHomeService.GetPeticomerHomeByUserIdAsync(userId));
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddPeticomerHome(PeticomerHomeModel peticomerHomeModel)
    {
        return CreateActionResult(await _peticomerHomeService.AddAsync(peticomerHomeModel));
    }
}