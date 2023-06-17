using Peticom.Core.Entities;

namespace Peticom.Core.Repositories;

public interface IAdRepository : IGenericRepository<Ad>
{
    public Task<List<Ad>> GetAllWithStarsAsync();
}