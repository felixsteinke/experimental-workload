using db_library_csharp.Entities.Abstractions;

namespace db_library_csharp.Entities;

public class Product : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ISet<Unit> Units { get; set; } = new HashSet<Unit>();
}
