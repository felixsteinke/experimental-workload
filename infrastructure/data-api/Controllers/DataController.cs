namespace data_api.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/data")]
public class DataController : ControllerBase
{

    private readonly ILogger<DataController> _logger;
    private readonly string _fileBasePath = "./Data/";

    private static bool _locationState0 = true;
    private static bool _plantState0 = true;

    public DataController(ILogger<DataController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/locations")]
    public ActionResult<string> GetLocations()
    {
        var locationFile = $"locations_{(_locationState0 ? 0 : 1)}.json";
        _logger.LogInformation($"Fetch {locationFile}");
        _locationState0 = !_locationState0;

        return Ok(System.IO.File.ReadAllText($"{_fileBasePath}{locationFile}"));
    }

    [HttpGet("/plants")]
    public ActionResult<string> GetPlants()
    {
        var plantsFile = $"plants_{(_plantState0 ? 0 : 1)}.json";
        _logger.LogInformation($"Fetch {plantsFile}");
        _plantState0 = !_plantState0;

        return Ok(System.IO.File.ReadAllText($"{_fileBasePath}{plantsFile}"));
    }
}