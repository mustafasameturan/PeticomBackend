using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class AdRepository : GenericRepository<Ad>, IAdRepository
{
    public AdRepository(PeticomDbContext dbContext) : base(dbContext)
    {
        
    }

    public async Task<List<Ad>> GetAllWithStarsAsync()
    {
        var ads = await _context.Ads
            .Include(a => a.Stars)
            .ToListAsync();

        return ads;
    }
}