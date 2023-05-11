using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class CommentRepository : GenericRepository<Comment>, ICommentRepository
{
    public CommentRepository(PeticomDbContext dbContext) : base(dbContext)
    {
        
    }
}