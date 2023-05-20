using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class AdRepository : GenericRepository<Ad>, IAdRepository
{
    public AdRepository(PeticomDbContext dbContext) : base(dbContext)
    {
        
    }
}