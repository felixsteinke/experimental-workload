using db_library_csharp.Data.Abstractions;
using db_library_csharp.Entities;
namespace graphql_api_dotnet;

public class Query
{
    public IQueryable<Product> AllProducts([Service] IEntityRepository<Product> repository)
    {
        return repository.Entities;
    }

    public IQueryable<Product> GetProduct([Service] IEntityRepository<Product> repository, int id)
    {
        return repository.GetById(id);
    }

    public IQueryable<Unit> AllUnits([Service] IEntityRepository<Unit> repository)
    {
        return repository.Entities;
    }

    public IQueryable<Unit> GetUnit([Service] IEntityRepository<Unit> repository, int id)
    {
        return repository.GetById(id);
    }
}
