using Frontend.ViewModels;

namespace Frontend.Services;

public interface IProductService
{
    Task<IEnumerable<ProductViewModel>> FindAllProducts();
}