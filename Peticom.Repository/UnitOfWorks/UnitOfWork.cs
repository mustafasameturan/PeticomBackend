using Core.UnitOfWorks;

namespace DataAccess.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly PeticomDbContext _context;

    public UnitOfWork(PeticomDbContext context)
    {
        _context = context;
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
}