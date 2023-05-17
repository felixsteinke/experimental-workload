using db_api_dotnet.Entities;
using Microsoft.EntityFrameworkCore;

namespace db_api_dotnet.Connectors;

public class ProductDbContext : DbContext
{
    private readonly string _connectionString;

    public virtual DbSet<ProductEntity> Products { get; set; }
    public virtual DbSet<ProductItemEntitiy> ProductItems { get; set; }

    public ProductDbContext(string connectionString) : base()
    {
        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }
}
