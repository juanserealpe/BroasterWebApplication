using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BroasterWebApp.Entities
{
    public class Product
{
    [Column("id_product")]  
    public int IdProduct { get; set; }

    [Column("name_product")]
    public string NameProduct { get; set; }

    [Column("description_product")]
    public string DescriptionProduct { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("category")]
    public string Category { get; set; }

    [Column("is_active")]
    public bool? IsActive { get; set; }
}
}