using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class PeticomerBadgeRepository : GenericRepository<PeticomerBadge>, IPeticomerBadgeRepository
{
    public PeticomerBadgeRepository(PeticomDbContext context) : base(context)
    {
    }
}