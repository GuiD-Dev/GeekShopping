using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTO;
using ProductAPI.Repositories;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController : Controller
{
    private readonly ILogger<ProductController> _logger;
    private readonly IProductRepository _productRepository;

    public ProductController(ILogger<ProductController> logger, IProductRepository productRepository)
    {
        _logger = logger;
        _productRepository = productRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ProductDTO>> FindAll()
    {
        _logger.LogInformation("Fetching all products");
        var products = _productRepository.FindAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDTO> FindById(long id)
    {
        _logger.LogInformation($"Fetching product with ID: {id}");
        var product = _productRepository.FindById(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpPost]
    public ActionResult<ProductDTO> Create(ProductDTO dto)
    {
        if (dto == null) return BadRequest();
        _logger.LogInformation("Creating a product");
        var product = _productRepository.Create(dto);
        return Ok(product);
    }

    [HttpPut]
    public ActionResult<ProductDTO> Update(ProductDTO dto)
    {
        if (dto == null) return BadRequest();
        _logger.LogInformation($"Updating a product");
        var product = _productRepository.Update(dto);
        return product == null ? Ok(product) : NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(long id)
    {
        _logger.LogInformation($"Deleting product with ID: {id}");
        var status = _productRepository.Delete(id);
        return status ? Ok(status) : BadRequest();
    }
}
