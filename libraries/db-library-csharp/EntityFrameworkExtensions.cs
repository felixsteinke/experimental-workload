using db_library_csharp.Data;
using db_library_csharp.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace db_library_csharp;

public static class EntityFrameworkExtensions
{
    public static void RegisterDbContext(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<AppDbContext>((options) =>
        {
            options.UseSqlServer(connectionString);
        },
        ServiceLifetime.Scoped,
        ServiceLifetime.Singleton
        );
        services.AddScoped(typeof(DbContext), typeof(AppDbContext));
        services.AddScoped(typeof(IEntityRepository<>), typeof(AppEntityRepository<>));
    }
}
