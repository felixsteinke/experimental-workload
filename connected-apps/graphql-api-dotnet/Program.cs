using db_library_csharp;

namespace graphql_api_dotnet;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        // GraphQL
        builder.Services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>();

        //.RegisterGraphTypes(typeof(Program).Assembly);

        // DB Conficugration
        var configuration = builder.Configuration;
        var connectionString = configuration.GetSection("ConnectionStrings:DbConnection").Value;
        builder.Services.RegisterDbContext(connectionString);

        // App Setup
        var app = builder.Build();

        app.MapGraphQL();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.Run();
    }
}