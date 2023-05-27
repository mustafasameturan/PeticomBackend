using Peticom.Core.Entities;
using Peticom.Core.Models.PeticomerBadge;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IPeticomerBadgeService : IGenericService<PeticomerBadge, PeticomerBadgeModel>
{
    Task<Response<List<PeticomerBadgeModel>>> GetPeticomerBadgeByUserIdAsync(string userId);
}