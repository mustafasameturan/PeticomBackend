using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PeticomerHomeRepository : GenericRepository<PeticomerHome>, IPeticomerHomeRepository
{
    public PeticomerHomeRepository(PeticomDbContext context) : base(context)
    {
    }

    /// <summary>
    /// This method is get peticomer home by user id.
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    public Task<List<PeticomerHome>> GetPeticomerHomeByUserIdAsync(string userId)
    {
        return _context.PeticomerHomes.Where(x => x.UserId == userId).ToListAsync();
    }
}