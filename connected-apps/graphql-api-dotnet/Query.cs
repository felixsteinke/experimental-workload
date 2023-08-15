using db_library_csharp.Data.Abstractions;
using db_library_csharp.Entities;
namespace graphql_api_dotnet;

public class Query
{
    public IQueryable<Unit> AllUnits([Service] IEntityRepository<Unit> repository)
    {
        return repository.Entities;
    }

    public IQueryable<Unit> GetUnit([Service] IEntityRepository<Unit> repository, int id)
    {
        return repository.GetById(id);
    }
}
