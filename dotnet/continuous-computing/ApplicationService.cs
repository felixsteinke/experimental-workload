namespace continuous_computing;

using Microsoft.Extensions.Logging;


public class ApplicationService
{
    private readonly ILogger _logger;

    public ApplicationService(ILogger logger)
    {
        _logger = logger;
    }

    public void Execute()
    {
        _logger.LogInformation("Executed continuous Application Job!");
    }
}
