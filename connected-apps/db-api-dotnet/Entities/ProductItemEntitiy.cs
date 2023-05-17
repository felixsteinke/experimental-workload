using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace db_api_dotnet.Entities;

[Table("items")]
public class ProductItemEntitiy
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(100)]
    public string Name { get; set; } = default!;

    [Column("description")]
    [StringLength(1000)]
    public string Description { get; set; } = default!;

    [ForeignKey("product_id")]
    [InverseProperty("ProductItems")]
    public virtual ProductEntity Product { get; set; } = default!;
}
