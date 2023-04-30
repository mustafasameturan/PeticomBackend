using System.Linq.Expressions;
using Core.Models;
using Core.Responses;

namespace Core.Services;

public interface IGenericService<TEntity, TModel> where TEntity : class where TModel : class
{
    // Get the entity by id
    Task<Response<TModel>> GetByIdAsync(Guid id);
    // Get all entities
    Task<Response<IEnumerable<TModel>>> GetAllAsync(); 
    // Get entities by expression
    Task<Response<IQueryable<TModel>>> Where(Expression<Func<TEntity, bool>> predicate);
    // Add entity
    Task<Response<TModel>> AddAsync(TModel entity);
    // Remove entity
    Task<Response<NoDataModel>> Remove(Guid id);
    //Update entity
    Task<Response<NoDataModel>> Update(TModel entity, Guid id);
}