using Microsoft.AspNetCore.Mvc;
using Peticom.Core.Models.Reservation;
using Peticom.Core.Services;

namespace Peticom.WebAPI.Controllers;

[Route("api/reservations")]
[ApiController]
public class ReservationController : BaseController
{ 
    private readonly IReservationService _reservationService;

    public ReservationController(IReservationService reservationService)
    {
        _reservationService = reservationService;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return CreateActionResult(await _reservationService.GetAllAsync());
    }
    
    [HttpGet("getByAdId")]
    public async Task<IActionResult> GetByAdId(Guid adId)
    {
        return CreateActionResult(await _reservationService.GetReservationsByAdId(adId));
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(ReservationModel model)
    {
        return CreateActionResult(await _reservationService.CreateReservation(model));
    }
}