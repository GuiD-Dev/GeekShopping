using System.ComponentModel.DataAnnotations.Schema;

namespace OrderAPI.Models;

[Table("order_detail")]
public class OrderDetail : BaseEntity
{
    public long OrderId { get; set; }

    [ForeignKey("OrderId")]
    public virtual Order Order { get; set; }

    [Column("ProductId")]
    public long ProductId { get; set; }

    [Column("count")]
    public int Count { get; set; }

    [Column("product_name")]
    public string ProductName { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

}
