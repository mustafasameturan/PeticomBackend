using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PetVaccineRepository : GenericRepository<PetVaccine>, IPetVaccineRepository 
{
    public PetVaccineRepository(PeticomDbContext context) : base(context)
    {
    }

    public async Task<List<PetVaccine>> GetPetVaccinesByPetIdAsync(Guid petId)
    {
        var petVaccines = await _context.PetVaccines.AsQueryable()
            .Where(p => p.PetId == petId)
            .ToListAsync();

        return petVaccines;
    }
}