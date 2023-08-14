using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace azure_sorting_function_csharp;

public class AzureFunctionStartup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        var hostconfig = builder.GetContext().Configuration;
        // set external configurations
        builder.Services.AddHttpContextAccessor();
        // add custom services for dependency injection
    }
}
