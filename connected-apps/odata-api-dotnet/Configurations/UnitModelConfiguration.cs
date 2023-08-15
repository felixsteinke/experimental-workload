using db_library_csharp.Entities;
using odata_api_dotnet.Configurations.Abstractions;
using odata_api_dotnet.Controllers;

namespace odata_api_dotnet.Configurations;

public class UnitModelConfiguration : VersionedModelConfigurationBase<Unit, UnitsController>
{ }
