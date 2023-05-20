using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PeticomerHomeRepository : GenericRepository<PeticomerHome>, IPeticomerHomeRepository
{
    public PeticomerHomeRepository(PeticomDbContext context) : base(context)
    {
    }
}