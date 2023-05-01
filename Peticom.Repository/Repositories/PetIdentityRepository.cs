using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class PetIdentityRepository : GenericRepository<PetIdentity>, IPetIdentityRepository
{
    public PetIdentityRepository(PeticomDbContext context) : base(context)
    {
    }
}