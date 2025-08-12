using AutoMapper;
using ProductAPI.DBContext;
using ProductAPI.DTO;
using ProductAPI.Models;

namespace ProductAPI.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly MySQLContext _context;
    private readonly IMapper _mapper;


    public ProductRepository(MySQLContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<ProductDTO> FindAll()
    {
        var products = _context.Products.ToList();
        return _mapper.Map<IEnumerable<ProductDTO>>(products);
    }

    public ProductDTO FindById(long id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return null;
        return _mapper.Map<ProductDTO>(product);
    }

    public ProductDTO Create(ProductDTO dto)
    {
        _context.Products.Add(_mapper.Map<Product>(dto));
        _context.SaveChanges();
        return dto;
    }

    public ProductDTO Update(ProductDTO dto)
    {
        _context.Products.Update(_mapper.Map<Product>(dto));
        _context.SaveChanges();
        return dto;
    }

    public bool Delete(long id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null) return false;
        _context.Products.Remove(product);
        _context.SaveChanges();
        return true;
    }
}