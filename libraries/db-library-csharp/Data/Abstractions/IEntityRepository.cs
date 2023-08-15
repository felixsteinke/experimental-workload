using db_library_csharp.Entities.Abstractions;

namespace db_library_csharp.Data.Abstractions;

public interface IEntityRepository<TEntity>
    where TEntity : class, IEntity
{
    IQueryable<TEntity> Entities { get; }
    IQueryable<TEntity> GetById(int key);
    TEntity Insert(TEntity entity);
    TEntity Update(TEntity entity);
    bool Delete(int key);
}
