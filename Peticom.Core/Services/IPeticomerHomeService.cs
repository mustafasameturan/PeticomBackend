using Peticom.Core.Entities;
using Peticom.Core.Models.PeticomerHome;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IPeticomerHomeService : IGenericService<PeticomerHome, PeticomerHomeModel>
{
    public Task<Response<List<PeticomerHomeModel>>> GetPeticomerHomeByUserIdAsync(string userId);
}