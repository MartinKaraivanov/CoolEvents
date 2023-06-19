using CoolEvents.Data.Models;
using System.Linq.Expressions;

namespace CoolEvents.Data;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    IEnumerable<TEntity> Retrieve(Expression<Func<TEntity, bool>> where);
    IEnumerable<T> RetrieveMappedTo<T>(Expression<Func<TEntity, bool>> where) where T : class;
    Task<TEntity> EditAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}
