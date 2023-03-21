namespace batch_computing;

using Microsoft.Extensions.Logging;


public class BatchService
{
    private readonly ILogger _logger;

    public BatchService(ILogger logger)
    {
        _logger = logger;
    }

    public void Execute()
    {
        _logger.LogInformation("Executed Batch Job!");
    }
}
