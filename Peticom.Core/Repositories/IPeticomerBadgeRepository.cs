using Peticom.Core.Entities;

namespace Peticom.Core.Repositories;

public interface IPeticomerBadgeRepository : IGenericRepository<PeticomerBadge>
{
    public Task<List<PeticomerBadge>> GetPeticomerBadgeByUserIdAsync(string userId);
}