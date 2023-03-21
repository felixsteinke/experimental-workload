namespace web_batch_api.Controllers;

using batch_computing;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("[controller]")]
public class BatchController : ControllerBase
{
    private readonly ILogger<BatchController> _logger;
    private readonly BatchService _service;

    public BatchController(ILogger<BatchController> logger)
    {
        _logger = logger;
        _service = new BatchService(logger);
    }

    [HttpGet(Name = "execute")]
    public ActionResult<string> Get()
    {
        _service.Execute();
        return Ok("Hello World!");
    }
}