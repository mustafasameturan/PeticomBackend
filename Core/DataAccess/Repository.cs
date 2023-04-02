using System.Linq.Expressions;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess;

public class Repository<TEntity, TContext> : IRepository<TEntity>
    where TEntity : BaseEntity, new()
    where TContext : DbContext
{
    protected TContext Context { get; }

    public Repository(TContext context)
    {
        Context = context;
    }

    public void Add(TEntity entity)
    {
        var addedEntity = Context.Entry(entity);
        addedEntity.State = EntityState.Added;
        Context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        var deletedEntity = Context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        Context.SaveChanges();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        return Context.Set<TEntity>().SingleOrDefault(filter);
    }

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        return filter == null
            ? Context.Set<TEntity>().ToList()
            : Context.Set<TEntity>().Where(filter).ToList();
    }

    public void Update(TEntity entity)
    {
        var UpdatedEntity = Context.Entry(entity);
        UpdatedEntity.State = EntityState.Modified;
        Context.SaveChanges();

    }
}    
    