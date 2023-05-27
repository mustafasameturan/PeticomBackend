using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.PetVaccine;
using Peticom.Core.Responses;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/petVaccines")]
[ApiController]
public class PetVaccinesController : BaseController
{
    private readonly IPetVaccineService _petVaccineService;
    
    public PetVaccinesController(IPetVaccineService petVaccineService)
    {
        _petVaccineService = petVaccineService;
    }
    
    /// <summary>
    /// This method is used to get all pet vaccines.
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _petVaccineService.GetAllAsync());
    }

    /// <summary>
    /// This method is used to add pet vaccine.
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost("add")]
    public async Task<IActionResult> AddPetVaccine(PetVaccineModel model)
    {
        return CreateActionResult(await _petVaccineService.AddAsync(model));
    }

}