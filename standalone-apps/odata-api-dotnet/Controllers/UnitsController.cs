using Asp.Versioning;
using db_library_csharp.Data.Abstractions;
using db_library_csharp.Entities;
using odata_api_dotnet.Controllers.Abstractions;

namespace odata_api_dotnet.Controllers;

[ApiVersion(ApiVersions.V1)]
public class UnitsController : ODataControllerBase<Unit>
{
    public UnitsController(ILogger<UnitsController> logger, IEntityRepository<Unit> repository)
        : base(logger, repository)
    { }
}
