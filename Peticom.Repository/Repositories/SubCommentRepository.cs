using Core.Entities;
using Core.Repositories;

namespace DataAccess.Repositories;

public class SubCommentRepository : GenericRepository<SubComment>, ISubCommentRepository
{
    public SubCommentRepository(PeticomDbContext dbContext) : base(dbContext)
    {
        
    }
}