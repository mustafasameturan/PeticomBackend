using Peticom.Core.Entities;
using Peticom.Core.Models;
using Peticom.Core.Models.PeticomerApplication;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface IPeticomerApplicationService : IGenericService<PeticomerApplication, PeticomerApplicationModel>
{
    public Task<Response<PeticomerApplicationWithStatusModel>> GetPeticomerApplicationByUserIdAsync(string userId);
    public Task<Response<PeticomerApplicationWithStatusModel>> GetPeticomerApplicationByIdAsync(Guid id);
    public Task<Response<List<PeticomerApplicationWithStatusModel>>> GetAllPeticomerApplicationsAsync();

    public Task<Response<PeticomerApplicationModel>> CreateApplication(PeticomerApplicationModel peticomerApplicationModel);
    public Task<Response<NoDataModel>> ApprovePeticomerApplicationByUserId(string userId);
    public Task<Response<NoDataModel>> RejectPeticomerApplicationByUserId(string userId);
}