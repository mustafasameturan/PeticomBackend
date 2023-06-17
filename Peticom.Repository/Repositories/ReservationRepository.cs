using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class ReservationRepository : GenericRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(PeticomDbContext context) : base(context)
    {
    }
}