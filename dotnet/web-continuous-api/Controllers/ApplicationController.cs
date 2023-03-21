namespace web_continuous_api.Controllers;

using continuous_computing;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class ApplicationController : ControllerBase
{
    private readonly ILogger<ApplicationController> _logger;
    private readonly ApplicationService _service;

    public ApplicationController(ILogger<ApplicationController> logger)
    {
        _logger = logger;
        _service = new ApplicationService(logger);
    }

    [HttpGet(Name = "execute")]
    public ActionResult<string> Get()
    {
        _service.Execute();
        return Ok("Hello World!");
    }
}