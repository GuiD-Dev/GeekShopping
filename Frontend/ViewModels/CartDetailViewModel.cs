namespace Frontend.ViewModels;

public class CartDetailViewModel
{
    public long Id { get; set; }
    public CartViewModel Cart { get; set; }
    public ProductViewModel Product { get; set; }
    public int Count { get; set; }
}