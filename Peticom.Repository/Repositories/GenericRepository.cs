using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Peticom.Core.Repositories;

namespace Peticom.Repository.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly PeticomDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(PeticomDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    /// <summary>
    /// This method is used to get the entity by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }
    
    /// <summary>
    /// This method is used to get all entities
    /// </summary>
    /// <returns></returns>
    public IQueryable<T> GetAll()
    {
        //AsNoTracking() is used to prevent data from being stored in memory
        //Performance is gained
        return _dbSet.AsNoTracking().AsQueryable();
    }

    /// <summary>
    /// This method is used to get all entities by expression
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public IQueryable<T> Where(Expression<Func<T, bool>> expression)
    {
        return _dbSet.Where(expression);
    }
    
    public IQueryable<T> Queryable() => _dbSet.AsQueryable();

    /// <summary>
    /// This method is used to check if entity exists by expression
    /// </summary>
    /// <param name="expression"></param>
    /// <returns></returns>
    public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
    {
        return await _dbSet.AnyAsync(expression);
    }

    /// <summary>
    /// This method is used to add entity
    /// </summary>
    /// <param name="entity"></param>
    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }
    
    /// <summary>
    /// This method is used to add entities
    /// </summary>
    /// <param name="entities"></param>
    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    /// <summary>
    /// This method is used to update entity
    /// </summary>
    /// <param name="entity"></param>
    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    /// <summary>
    /// This method is used to remove entity
    /// </summary>
    /// <param name="entity"></param>
    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    /// <summary>
    /// This method is used to remove entities
    /// </summary>
    /// <param name="entities"></param>
    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}