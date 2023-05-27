using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Models.Star;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class StarRepository : GenericRepository<Star>, IStarRepository 
{
    public StarRepository(PeticomDbContext context) : base(context)
    {
        
    }

    /// <summary>
    /// This method is get stars by user id.
    /// </summary>
    /// <param name="adId"></param>
    /// <returns></returns>
    public async Task<List<Star>> GetStarsByAdIdAsync(Guid adId)
    {
        return await _context.Stars.Where(s => s.AdId == adId).ToListAsync();
    }
}