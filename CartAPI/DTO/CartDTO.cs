namespace CartAPI.DTO;

public class CartDTO
{
    public long Id { get; set; }
    public string UserId { get; set; }
    public string CouponCode { get; set; }
    public IEnumerable<CartDetailDTO> Details { get; set; }
}