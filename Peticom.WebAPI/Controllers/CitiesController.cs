using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.City;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/cities")]
[ApiController]
public class CitiesController : BaseController
{
    private readonly ICityService _cityService;

    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _cityService.GetAllAsync());
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody] CityModel city)
    {
        return CreateActionResult(await _cityService.AddAsync(city));
    }
}