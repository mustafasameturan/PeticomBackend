using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PetDiseaseRepository : GenericRepository<PetDisease>, IPetDiseaseRepository
{
    public PetDiseaseRepository(PeticomDbContext context) : base(context)
    {
        
    }
}