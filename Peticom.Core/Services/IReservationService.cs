using Peticom.Core.Entities;
using Peticom.Core.Models.Reservation;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IReservationService : IGenericService<Reservation, ReservationModel>
{
    Task<Response<List<ReservationModel>>> GetReservationsByAdId(Guid adId); 
    Task<Response<ReservationModel>> CreateReservation(ReservationModel reservationModel);
}