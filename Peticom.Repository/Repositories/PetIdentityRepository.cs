using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class PetIdentityRepository : GenericRepository<PetIdentity>, IPetIdentityRepository
{
    public PetIdentityRepository(PeticomDbContext context) : base(context)
    {
    }

    public async Task<List<PetIdentity>> GetPetIdentityByUserIdAsync(string userId)
    {
        return await _context.PetIdentities.AsQueryable()
            .Where(p => p.UserId == userId)
            .ToListAsync();
    }
}