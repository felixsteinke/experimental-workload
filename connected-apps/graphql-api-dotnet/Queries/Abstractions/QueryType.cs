using db_library_csharp.Data.Abstractions;
using db_library_csharp.Entities.Abstractions;

namespace graphql_api_dotnet.Queries.Abstractions;

public abstract class QueryType<TEntity>
    where TEntity : class, IEntity
{
    public IQueryable<TEntity> All([Service] IEntityRepository<TEntity> repository)
    {
        return repository.Entities;
    }

    public IQueryable<TEntity> Get([Service] IEntityRepository<TEntity> repository, int id)
    {
        return repository.GetById(id);
    }
}
