using CoolEvents.Data.Models;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolEvents.Data.EF.Repositories;

public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly CoolEventsDbContext _dbContext;
    public BaseRepository(CoolEventsDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbContext.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> EditAsync(TEntity entity)
    {
        _dbContext.Update(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task RemoveAsync(TEntity entity)
    {
        _dbContext.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public IQueryable<TEntity> RetrieveAll()
    {
        return _dbContext.Set<TEntity>();
    }
}
