using db_library_csharp.Entities.Abstractions;
using Microsoft.Extensions.Logging;

namespace db_library_csharp.Data.Abstractions;

public class AppEntityRepository<TEntity> : EntityRepositoryBase<AppDbContext, TEntity>
    where TEntity : class, IEntity
{
    public AppEntityRepository(AppDbContext context, ILogger<EntityRepositoryBase<AppDbContext, TEntity>> logger)
        : base(context, logger)
    { }
}
