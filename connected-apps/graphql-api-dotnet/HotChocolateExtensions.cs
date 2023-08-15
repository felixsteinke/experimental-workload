using graphql_api_dotnet.Mutations.Abstractions;
using graphql_api_dotnet.Queries.Abstractions;
using HotChocolate.Execution.Configuration;
using System.Reflection;

namespace db_library_csharp;

public static class HotChocolateExtensions
{
    public static void RegisterGraphTypes(this IRequestExecutorBuilder graphBuilder, Assembly assemply)
    {
        var graphTypes = assemply.GetTypes().Where(IsGraphType);
        foreach (var type in graphTypes)
        {
            graphBuilder.AddType(type);
        }
    }

    private static bool IsGraphType(Type type)
    {
        return type.BaseType != null
            && type.BaseType.IsGenericType
            && (type.BaseType.GetGenericTypeDefinition() == typeof(QueryType<>)
            || type.BaseType.GetGenericTypeDefinition() == typeof(MutationType<>));
    }
}
