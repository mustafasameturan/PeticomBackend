using Peticom.Core.Entities;
using Peticom.Core.Models.Star;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IStarService : IGenericService<Star, StarModel>
{
    public Task<Response<List<StarModel>>> GetStarsByAdIdAsync(Guid adId);
}