using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class StarRepository : GenericRepository<Star>, IStarRepository 
{
    public StarRepository(PeticomDbContext context) : base(context)
    {
        
    }
}