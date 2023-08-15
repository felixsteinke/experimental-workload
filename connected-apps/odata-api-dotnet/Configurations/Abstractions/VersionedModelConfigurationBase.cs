using Asp.Versioning;
using Asp.Versioning.OData;
using db_library_csharp.Entities.Abstractions;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData.ModelBuilder;

namespace odata_api_dotnet.Configurations.Abstractions
{
    public abstract class VersionedModelConfigurationBase<TEntity, TController> : IModelConfiguration
    where TEntity : class, IEntity
    where TController : ODataController
    {
        /// <inheritdoc />
        public void Apply(ODataModelBuilder builder, ApiVersion apiVersion, string? routePrefix)
        {
            if (builder is null || routePrefix is null || !routePrefix.Equals(RoutePrefix.ApiVersion, StringComparison.Ordinal))
            {
                return;
            }
            var entityName = GetEntityName<TController>();
            var entity = builder.EntitySet<TEntity>(entityName);
            entity = ConfigureEntitySet(entity);
            ConfigureEntityType(entity.EntityType);
        }

        protected static string GetEntityName<TEntityController>()
            where TEntityController : ODataController =>
            typeof(TEntityController).Name.Replace(
                "Controller",
                string.Empty,
                StringComparison.OrdinalIgnoreCase
            );

        protected virtual EntitySetConfiguration<TEntity> ConfigureEntitySet(
            EntitySetConfiguration<TEntity> entitySet
        ) => entitySet;

        protected virtual EntityTypeConfiguration<TEntity> ConfigureEntityType(
            EntityTypeConfiguration<TEntity> entityType
        ) => entityType;
    }
}
