using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class PetDiseaseRepository : GenericRepository<PetDisease>, IPetDiseaseRepository
{
    public PetDiseaseRepository(PeticomDbContext context) : base(context)
    {
        
    }
}