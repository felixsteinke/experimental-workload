using db_library_csharp.Entities;
using Microsoft.EntityFrameworkCore;

namespace db_library_csharp.Data;

public class AppDbContext : DbContext
{
    public DbSet<Product> Products { get; set; } = default!;
    public DbSet<Unit> Units { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
}
