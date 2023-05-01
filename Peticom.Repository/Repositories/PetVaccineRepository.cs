using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class PetVaccineRepository : GenericRepository<PetVaccine>, IPetVaccineRepository 
{
    public PetVaccineRepository(PeticomDbContext context) : base(context)
    {
    }
}