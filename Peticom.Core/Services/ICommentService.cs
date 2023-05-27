using Peticom.Core.Entities;
using Peticom.Core.Models.Comment;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

public interface ICommentService : IGenericService<Comment, CommentModel>
{
    public Task<Response<List<CommentWithSubCommentModel>>> GetCommentsWithSubCommentsAsync();
}