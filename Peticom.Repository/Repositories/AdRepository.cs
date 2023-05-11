using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class AdRepository : GenericRepository<Ad>, IAdRepository
{
    public AdRepository(PeticomDbContext dbContext) : base(dbContext)
    {
        
    }
}