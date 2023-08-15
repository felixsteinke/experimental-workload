using db_library_csharp.Data.Abstractions;
using db_library_csharp.Entities.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using static System.Net.Mime.MediaTypeNames;

namespace odata_api_dotnet.Controllers.Abstractions;

[Produces(
    Application.Json + @";odata.metadata=minimal;odata.streaming=true",
    Application.Json + @";odata.metadata=full;odata.streaming=true",
    Application.Json
)]
[Consumes(
    Application.Json + @";odata.metadata=minimal;odata.streaming=true",
    Application.Json + @";odata.metadata=full;odata.streaming=true",
    Application.Json
)]
public abstract class ODataControllerBase<TEntity> : ODataController
    where TEntity : class, IEntity
{
    protected ILogger Logger { get; }
    protected IEntityRepository<TEntity> Repository { get; }

    protected ODataControllerBase(ILogger<ODataControllerBase<TEntity>> logger, IEntityRepository<TEntity> repository)
    {
        Logger = logger;
        Repository = repository;
    }

    [HttpGet]
    [EnableQuery(MaxExpansionDepth = 3, PageSize = 50)]
    public ActionResult<IQueryable<TEntity>> Get()
    {
        using (Logger.BeginScope(nameof(Get)))
        {
            return Ok(Repository.Entities);
        }
    }

    [HttpGet]
    [EnableQuery(MaxExpansionDepth = 3, PageSize = 50)]
    public ActionResult<SingleResult<TEntity>> Get(int key)
    {
        using (Logger.BeginScope(nameof(Get)))
        {
            var entity = Repository.GetById(key);
            return Ok(SingleResult.Create(entity));
        }
    }

    [HttpPost]
    [EnableQuery(PageSize = 50)]
    public ActionResult<TEntity> Post([FromBody] TEntity data)
    {
        using (Logger.BeginScope(nameof(Post)))
        {
            var addedEntity = Repository.Insert(data);
            return Created(addedEntity);
        }
    }

    [HttpPut]
    [EnableQuery(PageSize = 50)]
    public ActionResult<TEntity> Put([FromRoute] int key, [FromBody] Delta<TEntity> delta)
    {
        using (Logger.BeginScope(nameof(Put)))
        {
            var entities = Repository.GetById(key);
            var entity = entities.First();
            delta.Put(entity);
            var updatedEntity = Repository.Update(entity);
            return Updated(updatedEntity);
        }
    }

    [HttpDelete]
    public IActionResult Delete([FromRoute] int id)
    {
        using (Logger.BeginScope(nameof(Delete)))
        {
            Repository.Delete(id);
            return NoContent();
        }
    }
}
