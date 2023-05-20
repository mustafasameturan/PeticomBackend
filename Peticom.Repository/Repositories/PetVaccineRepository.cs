using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PetVaccineRepository : GenericRepository<PetVaccine>, IPetVaccineRepository 
{
    public PetVaccineRepository(PeticomDbContext context) : base(context)
    {
    }
}