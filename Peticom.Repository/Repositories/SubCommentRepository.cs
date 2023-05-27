using Microsoft.EntityFrameworkCore;
using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class SubCommentRepository : GenericRepository<SubComment>, ISubCommentRepository
{
    public SubCommentRepository(PeticomDbContext context) : base(context)
    {
        
    }

    /// <summary>
    /// This method get sub comments for server.
    /// </summary>
    /// <param name="commentId"></param>
    /// <returns></returns>
    public async Task<List<SubComment>> GetSubCommentsByCommentId(Guid commentId)
    {
        return await _context.SubComments.AsQueryable()
            .Where(x => x.CommentId == commentId).ToListAsync();
    }
}