using db_library_csharp.Data.Abstractions;
using db_library_csharp.Entities.Abstractions;

namespace graphql_api_dotnet.Mutations.Abstractions;

public abstract class MutationType<TEntity>
    where TEntity : class, IEntity
{
    public TEntity Add([Service] IEntityRepository<TEntity> repository, TEntity entity)
    {
        return repository.Insert(entity);
    }

    public TEntity Update([Service] IEntityRepository<TEntity> repository, TEntity entity)
    {
        return repository.Update(entity);
    }

    public bool Delete([Service] IEntityRepository<TEntity> repository, int id)
    {
        return repository.Delete(id);
    }
}
