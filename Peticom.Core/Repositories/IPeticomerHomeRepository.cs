using Peticom.Core.Entities;

namespace Peticom.Core.Repositories;

public interface IPeticomerHomeRepository : IGenericRepository<PeticomerHome>
{
    public Task<List<PeticomerHome>> GetPeticomerHomeByUserIdAsync(string userId);
}