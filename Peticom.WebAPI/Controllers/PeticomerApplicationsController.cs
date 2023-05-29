using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.PeticomerApplication;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/peticomerApplications")]
[ApiController]
public class PeticomerApplicationsController : BaseController
{
    private readonly IPeticomerApplicationService _peticomerApplicationService;
    private readonly IEmailService _emailService;

    public PeticomerApplicationsController(IPeticomerApplicationService peticomerApplicationService, IEmailService emailService)
    {
        _peticomerApplicationService = peticomerApplicationService;
        _emailService = emailService;
    }
    
    /// <summary>
    /// This method is used to get all peticomer applications.
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _peticomerApplicationService.GetAllAsync());
    }

    /// <summary>
    /// This method get all peticomer applications by status.
    /// </summary>
    /// <returns></returns>
    [HttpGet("getAllWithStatus")]
    public async Task<IActionResult> GetAllWithStatus()
    {
        return CreateActionResult(await _peticomerApplicationService.GetAllPeticomerApplicationsAsync());
    }

    /// <summary>
    /// This method get peticomer application with status by application id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("getByApplicationId")]
    public async Task<IActionResult> GetPeticomerApplicationById(Guid id)
    {
        return CreateActionResult(await _peticomerApplicationService.GetPeticomerApplicationByIdAsync(id));
    }

    /// <summary>
    /// This method is get peticomer application by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpGet("getByUserId")]
    public async Task<IActionResult> GetPeticomerApplicationByUserId(string userId)
    {
        return CreateActionResult(await _peticomerApplicationService.GetPeticomerApplicationByUserIdAsync(userId));
    }
    
    /// <summary>
    /// This method is used to add a peticomer application.
    /// </summary>
    /// <param name="peticomerApplicationModel"></param>
    /// <returns></returns>
    [HttpPost("createApplication")]
    public async Task<IActionResult> CreatePeticomerApplication(PeticomerApplicationModel peticomerApplicationModel)
    {
        return CreateActionResult(await _peticomerApplicationService.CreateApplication(peticomerApplicationModel));
    }

    /// <summary>
    /// This method approve the peticomer application by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPost("approveApplication/{userId}")]
    public async Task<IActionResult> ApprovePeticomerApplicationByUserId(string userId)
    {
        return CreateActionResult(await _peticomerApplicationService.ApprovePeticomerApplicationByUserId(userId));
    }

    /// <summary>
    /// This method reject the peticomer application by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    [HttpPost("rejectApplication/{userId}")]
    public async Task<IActionResult> RejectPeticomerApplicationByUserId(string userId)
    {
        return CreateActionResult(await _peticomerApplicationService.RejectPeticomerApplicationByUserId(userId));
    }
}