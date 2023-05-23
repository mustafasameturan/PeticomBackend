using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PetDiseaseRepository : GenericRepository<PetDisease>, IPetDiseaseRepository
{
    public PetDiseaseRepository(PeticomDbContext context) : base(context)
    {
        
    }

    public async Task<List<PetDisease>> GetPetDiseasesByPetIdAsync(Guid petId)
    {
        var petDiseases = await _context.PetDiseases.AsQueryable()
            .Where(p => p.PetId == petId)
            .ToListAsync();

        return petDiseases;
    }
}