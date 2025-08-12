using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductAPI.Models;

[Table("product")]
public class Product : BaseEntity
{
    [Column("name")]
    [Required(ErrorMessage = "The field Name is required.")]
    [StringLength(150, ErrorMessage = "The field Name must have a maximum length of 150 characters.")]
    public string Name { get; set; }

    [Column("price")]
    [Required(ErrorMessage = "The field Price is required.")]
    [Range(1, 10000, ErrorMessage = "The field Price must be between 0 and 10000.")]
    public decimal Price { get; set; }

    [Column("description")]
    [StringLength(500, ErrorMessage = "The field Description must have a maximum length of 500 characters.")]
    public string Description { get; set; }

    [Column("category")]
    [StringLength(50, ErrorMessage = "The field Category must have a maximum length of 50 characters.")]
    public string Category { get; set; }

    [Column("image_url")]
    [StringLength(300, ErrorMessage = "The field ImageUrl must have a maximum length of 300 characters.")]
    public string ImageUrl { get; set; }
}
