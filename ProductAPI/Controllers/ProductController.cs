using Microsoft.AspNetCore.Mvc;
using ProductAPI.DTO;
using ProductAPI.Repositories;

namespace ProductAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ProductController(ILogger<ProductController> logger, IProductRepository productRepository) : Controller
{
    [HttpGet]
    public ActionResult<IEnumerable<ProductDTO>> FindAll()
    {
        logger.LogInformation("Fetching all products");

        var products = productRepository.FindAll();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public ActionResult<ProductDTO> FindById(long id)
    {
        logger.LogInformation($"Fetching product with ID: {id}");

        var product = productRepository.FindById(id);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpPost]
    public ActionResult<ProductDTO> Create(ProductDTO dto)
    {
        if (dto == null) return BadRequest();

        logger.LogInformation("Creating a product");

        var product = productRepository.Create(dto);
        return Ok(product);
    }

    [HttpPut]
    public ActionResult<ProductDTO> Update(ProductDTO dto)
    {
        if (dto == null) return BadRequest();

        logger.LogInformation($"Updating a product");

        var product = productRepository.Update(dto);
        return product != null ? Ok(product) : NotFound();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(long id)
    {
        logger.LogInformation($"Deleting product with ID: {id}");

        var status = productRepository.Delete(id);
        return status ? Ok(status) : BadRequest();
    }
}
