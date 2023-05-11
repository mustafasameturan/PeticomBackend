using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class StarRepository : GenericRepository<Star>, IStarRepository 
{
    public StarRepository(PeticomDbContext context) : base(context)
    {
        
    }
}