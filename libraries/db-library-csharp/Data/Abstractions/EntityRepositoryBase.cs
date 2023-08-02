using db_library_csharp.Entities.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace db_library_csharp.Data.Abstractions;

public class EntityRepositoryBase<TContext, TEntity> : IEntityRepository<TEntity>
    where TContext : DbContext
    where TEntity : class, IEntity
{
    protected TContext Context { get; }
    protected ILogger Logger { get; }

    protected EntityRepositoryBase(TContext context, ILogger<EntityRepositoryBase<TContext, TEntity>> logger)
    {
        Context = context;
        Logger = logger;
    }

    public IQueryable<TEntity> Entities => Context.Set<TEntity>().AsQueryable();

    public IQueryable<TEntity> GetById(int key)
    {
        return Context.Set<TEntity>().Where(x => x.Id == key);
    }

    public TEntity Insert(TEntity entity)
    {
        var savedEntity = Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
        return savedEntity.Entity;
    }

    public TEntity Update(TEntity entity)
    {
        var updatedEntity = Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
        return updatedEntity.Entity;
    }

    public bool Delete(int key)
    {
        var entities = GetById(key);
        var deletedRows = entities.ExecuteDelete();
        return deletedRows > 0;
    }
}
