using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    public CityRepository(PeticomDbContext context) : base(context)
    {
    }
}