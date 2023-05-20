using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IAdService : IGenericService<Ad, AdModel>
{
    public Task<Response<AdFilterResponseModel>> GetAdsByFilterAsync(AdFilterRequestModel requestModel);
}