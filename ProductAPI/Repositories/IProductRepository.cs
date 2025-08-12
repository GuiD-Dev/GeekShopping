using ProductAPI.DTO;

namespace ProductAPI.Repositories;

public interface IProductRepository
{
    IEnumerable<ProductDTO> FindAll();
    ProductDTO FindById(long id);
    ProductDTO Create(ProductDTO dto);
    ProductDTO Update(ProductDTO dto);
    bool Delete(long id);
}