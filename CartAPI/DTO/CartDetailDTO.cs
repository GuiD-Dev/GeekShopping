namespace CartAPI.DTO;

public class CartDetailDTO
{
    public long Id { get; set; }
    public CartDTO Cart { get; set; }
    public ProductDTO Product { get; set; }
    public int Count { get; set; }

}