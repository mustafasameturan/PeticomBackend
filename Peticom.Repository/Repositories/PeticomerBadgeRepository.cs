using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PeticomerBadgeRepository : GenericRepository<PeticomerBadge>, IPeticomerBadgeRepository
{
    public PeticomerBadgeRepository(PeticomDbContext context) : base(context)
    {
    }

    /// <summary>
    /// This method get peticomer badge by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<List<PeticomerBadge>> GetPeticomerBadgeByUserIdAsync(string userId)
    {
        return await _context.PeticomerBadges.Where(x => x.UserId == userId).ToListAsync();
    }
}