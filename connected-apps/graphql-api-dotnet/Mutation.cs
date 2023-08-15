using db_library_csharp.Data.Abstractions;
using db_library_csharp.Entities;
namespace graphql_api_dotnet;
public class Mutation
{
    public Unit AddUnit([Service] IEntityRepository<Unit> repository, Unit entity)
    {
        return repository.Insert(entity);
    }
    public Unit UpdateUnit([Service] IEntityRepository<Unit> repository, Unit entity)
    {
        return repository.Update(entity);
    }

    public bool DeleteUnit([Service] IEntityRepository<Unit> repository, int id)
    {
        return repository.Delete(id);
    }
}
