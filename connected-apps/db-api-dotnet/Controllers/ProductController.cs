using db_api_dotnet.Connectors;
using db_api_dotnet.Entities;
using Microsoft.AspNetCore.Mvc;

namespace db_api_dotnet.Controllers;

[ApiController]
[Route("/api/product")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ProductDbContext _productDb;

    public ProductController(ILogger<ProductController> logger)
    {
        _logger = logger;
        _productDb = new ProductDbContext("Server=localhost;User ID=felixsteinke;Password=Password123;Database=energy1;Trusted_Connection=True;TrustServerCertificate=True");
    }

    [HttpGet("{id}")]
    public ActionResult<ProductEntity> Get(int id)
    {
        _logger.LogInformation("Select objects with id={Id}.", id);
        var entity = _productDb.Products.Where(entity => entity.Id == id).First();
        return Ok(entity);
    }

    [HttpGet("{idStart}-{idEnd}")]
    public ActionResult<IEnumerable<ProductEntity>> Get(int idStart, int idEnd)
    {
        _logger.LogInformation("Select objects in range: {Start} <= id <= {End}.", idStart, idEnd);
        var entities = _productDb.Products.Where(entity => idStart <= entity.Id && entity.Id <= idEnd).OrderBy(entity => entity.Id);
        return Ok(entities);
    }

    [HttpPost("")]
    public ActionResult<ProductEntity> Post(ProductEntity model)
    {
        _logger.LogInformation("Insert object with name={Name}.", model.Name);
        var createdEntity = _productDb.Add(model);
        _productDb.SaveChanges();
        return Ok(createdEntity);
    }

    [HttpPut("")]
    public ActionResult<ProductEntity> Put(ProductEntity model)
    {
        _logger.LogInformation("Update object with id={Id} and name={Name}.", model.Id, model.Name);
        var modifiedEntity = _productDb.Update(model);
        _productDb.SaveChanges();
        return Ok(modifiedEntity);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _logger.LogInformation("Delete object with id={Id}.", id);
        var entity = _productDb.Products.Where(entity => entity.Id == id).FirstOrDefault();
        if (entity == default)
        {
            _logger.LogInformation("Object with id={Id} does not exist.", id);
            return NotFound();
        }
        _productDb.Remove(entity);
        _productDb.SaveChanges();
        return NoContent();
    }
}
