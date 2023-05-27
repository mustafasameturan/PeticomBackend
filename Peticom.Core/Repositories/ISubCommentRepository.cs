using Peticom.Core.Entities;

namespace Peticom.Core.Repositories;

public interface ISubCommentRepository : IGenericRepository<SubComment>
{
    public Task<List<SubComment>> GetSubCommentsByCommentId(Guid commentId);
}