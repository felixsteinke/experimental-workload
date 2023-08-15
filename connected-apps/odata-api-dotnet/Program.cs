using db_library_csharp.Data;
using db_library_csharp.Data.Abstractions;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

namespace odata_api_dotnet;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        // Add services to the container.
        builder.Services.AddControllers()
        .AddControllersAsServices()
        .AddOData(options =>
        {
            options.EnableQueryFeatures(100);
            options.RouteOptions.EnableKeyAsSegment = true;
            options.RouteOptions.EnableKeyInParenthesis = false;
            options.RouteOptions.EnableNonParenthesisForEmptyParameterFunction = true;
            options.RouteOptions.EnablePropertyNameCaseInsensitive = true;
            options.RouteOptions.EnableQualifiedOperationCall = false;
            options.RouteOptions.EnableUnqualifiedOperationCall = true;
            options.EnableNoDollarQueryOptions = false;
        });
        builder.Services
            .AddEndpointsApiExplorer()
            .AddApiVersioning(options =>
            {
                options.DefaultApiVersion = ApiVersions.ApiVersion1;
                options.ReportApiVersions = true;
            })
            .AddOData(options =>
            {
                options.AddRouteComponents(RoutePrefix.Api);
                options.AddRouteComponents(RoutePrefix.ApiVersion);
            })
            .AddODataApiExplorer(options =>
            {
                options.DefaultApiVersion = ApiVersions.ApiVersion1;
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });


        var configuration = builder.Configuration;
        var connectionString = configuration.GetSection("ConnectionStrings:DbConnection").Value;
        builder.Services.AddDbContext<AppDbContext>((options) =>
        {
            options.UseSqlServer(connectionString);
        },
        ServiceLifetime.Scoped,
        ServiceLifetime.Singleton
        );
        builder.Services.AddScoped(typeof(DbContext), typeof(AppDbContext));
        builder.Services.AddScoped(typeof(IEntityRepository<>), typeof(AppEntityRepository<>));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}