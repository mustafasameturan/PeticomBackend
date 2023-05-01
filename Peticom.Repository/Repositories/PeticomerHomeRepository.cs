using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class PeticomerHomeRepository : GenericRepository<PeticomerHome>, IPeticomerHomeRepository
{
    public PeticomerHomeRepository(PeticomDbContext context) : base(context)
    {
    }
}