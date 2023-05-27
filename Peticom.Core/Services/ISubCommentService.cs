using Peticom.Core.Entities;
using Peticom.Core.Models.SubComment;

namespace Peticom.Core.Services;

public interface ISubCommentService : IGenericService<SubComment, SubCommentModel>
{
    public Task<List<SubCommentModel>> GetSubCommentsByCommentIdAsync(Guid commentId);
}