using Microsoft.AspNetCore.Mvc;
using sorting_library_csharp;

namespace sorting_api_dotnet.Controllers;

[ApiController]
[Route("/api")]
public class SortingController : ControllerBase
{
    private readonly ILogger<SortingController> _logger;

    public SortingController(ILogger<SortingController> logger)
    {
        _logger = logger;
    }

    [HttpPost("sort-on1")]
    public IEnumerable<int> SortOn1(List<int> requestBody)
    {
        _logger.LogInformation($"Sorting {requestBody.Count} items in O(n*log(n)).");
        SortingProcessor.SortInON1(requestBody);
        return requestBody;
    }

    [HttpPost("sort-on2")]
    public IEnumerable<int> SortOn2(List<int> requestBody)
    {
        _logger.LogInformation($"Sorting {requestBody.Count} items in O(n^2).");
        SortingProcessor.SortInON2(requestBody);
        return requestBody;
    }

    [HttpPost("sort-on3")]
    public IEnumerable<int> SortOn3(List<int> requestBody)
    {
        _logger.LogInformation($"Sorting {requestBody.Count} items in O(n^3).");
        SortingProcessor.SortInON3(requestBody);
        return requestBody;
    }
}