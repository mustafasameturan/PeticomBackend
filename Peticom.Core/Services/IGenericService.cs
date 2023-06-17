using System.Linq.Expressions;
using Peticom.Core.Models;
using Peticom.Core.Responses;

namespace Peticom.Core.Services;

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
    Task<Response<NoDataModel>> RemoveAsync(Guid id);
    //Update entity
    Task<Response<NoDataModel>> UpdateAsync(TModel entity);
}