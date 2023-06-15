using CoolEvents.Data.Models;

namespace CoolEvents.Data;

public interface IRepository<TEntity> where TEntity : IEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    IQueryable<TEntity> RetrieveAll();
    Task<TEntity> EditAsync(TEntity entity);
    Task RemoveAsync(TEntity entity);
}
