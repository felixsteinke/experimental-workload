using db_library_csharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace db_library_csharp;

public class AppContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    // dotnet ef migrations add InitialCreate
    // dotnet ef database update
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer("Server=localhost;User ID=username;Password=password;Database=exp-db-library-csharp;Trusted_Connection=True;TrustServerCertificate=True");

        return new AppDbContext(optionsBuilder.Options);
    }
}
