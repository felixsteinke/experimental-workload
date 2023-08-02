using db_library_csharp.Entities.Abstractions;

namespace db_library_csharp.Entities;

public class Unit : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
}
