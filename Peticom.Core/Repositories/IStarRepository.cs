using Peticom.Core.Entities;
using Peticom.Core.Models.Star;

namespace Peticom.Core.Repositories;

public interface IStarRepository : IGenericRepository<Star>
{
    public Task<List<Star>> GetStarsByAdIdAsync(Guid adId);
}