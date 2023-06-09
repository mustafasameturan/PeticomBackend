using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.PetDisease;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/petDiseases")]
[ApiController]
public class PetDiseasesController : BaseController
{
    private readonly IPetDiseaseService _petDiseaseService;
    
    public PetDiseasesController(IPetDiseaseService petDiseaseService)
    {
        _petDiseaseService = petDiseaseService;
    }
    
    /// <summary>
    /// This method is used to get all pet diseases
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _petDiseaseService.GetAllAsync());
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddPetDisease(PetDiseaseModel diseaseModel)
    {
        return CreateActionResult(await _petDiseaseService.AddAsync(diseaseModel));
    }
}