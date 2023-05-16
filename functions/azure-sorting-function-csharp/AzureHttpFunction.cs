using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using sorting_library_csharp;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace azure_sorting_function_csharp;

public static class AzureHttpFunction
{

    [FunctionName("sorting-fast")]
    public static async Task<IActionResult> RunFast(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        // Logging
        log.LogInformation($"Azure HTTP [{req.Method}] function processed a fast request with body: {req.Body}");
        // Validation
        if (req.Body.Length == 0)
        {
            return new BadRequestObjectResult("Only POST requests with body can be processed.");
        }
        // Process
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        List<int> list = JsonConvert.DeserializeObject<List<int>>(requestBody);
        SortingProcessor.SortInON1(list);
        // Response
        return new OkObjectResult(list);
    }

    [FunctionName("sorting-slow")]
    public static async Task<IActionResult> RunSlow(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        // Logging
        log.LogInformation($"Azure HTTP [{req.Method}] function processed a slow request with body: {req.Body}");
        // Validation
        if (req.Body.Length == 0)
        {
            return new BadRequestObjectResult("Only POST requests with body can be processed.");
        }
        // Process
        string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        List<int> list = JsonConvert.DeserializeObject<List<int>>(requestBody);
        SortingProcessor.SortInON2(list);
        // Response
        return new OkObjectResult(list);
    }
}
