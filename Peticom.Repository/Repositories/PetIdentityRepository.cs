using Core.Entities;
using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories;

public class PetIdentityRepository : GenericRepository<PetIdentity>, IPetIdentityRepository
{
    public PetIdentityRepository(PeticomDbContext context) : base(context)
    {
    }

    public async Task<List<PetIdentity>> GetPetIdentitiesByUserIdAsync(string userId)
    {
        return await _context.PetIdentities.Where(p => p.UserId == userId).ToListAsync();
    }
}