using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PeticomerBadgeRepository : GenericRepository<PeticomerBadge>, IPeticomerBadgeRepository
{
    public PeticomerBadgeRepository(PeticomDbContext context) : base(context)
    {
    }
}