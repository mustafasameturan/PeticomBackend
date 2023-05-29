using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PeticomerApplicationRepository : GenericRepository<PeticomerApplication>, IPeticomerApplicationRepository
{
    public PeticomerApplicationRepository(PeticomDbContext context) : base(context)
    {
    }
}