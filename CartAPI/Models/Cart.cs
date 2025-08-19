using System.ComponentModel.DataAnnotations.Schema;

namespace CartAPI.Models;

[Table("cart")]
public class Cart : BaseEntity
{
    [Column("user_id")]
    public string UserId { get; set; }

    [Column("coupon_code")]
    public string CouponCode { get; set; }

    public IEnumerable<CartDetail> Details { get; set; }
}
