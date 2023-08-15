using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace db_api_dotnet.Entities;

[Table("products")]
public class ProductEntity
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

    [InverseProperty("Product")]
    public virtual ICollection<ProductItemEntitiy> ProductItems { get; } = new List<ProductItemEntitiy>();
}
