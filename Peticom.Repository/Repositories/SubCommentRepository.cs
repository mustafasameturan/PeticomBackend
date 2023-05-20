using Peticom.Core.Entities;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class SubCommentRepository : GenericRepository<SubComment>, ISubCommentRepository
{
    public SubCommentRepository(PeticomDbContext dbContext) : base(dbContext)
    {
        
    }
}