using Asp.Versioning;

namespace odata_api_dotnet;

public static class ApiVersions
{
    public const string V1 = "1";
    public readonly static ApiVersion ApiVersion1 = new ApiVersion(1);
}

public static class RoutePrefix
{
    public const string Api = "api";
    public const string ApiVersion = "api/v1";
}

