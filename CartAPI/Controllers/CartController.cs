using Microsoft.AspNetCore.Mvc;
using CartAPI.Repositories;
using CartAPI.DTO;

namespace CartAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CartController(ICartRepository cartRepository) : Controller
{
    [HttpGet("{userId}")]
    public async Task<ActionResult<CartDTO>> FindById(string userId)
    {
        var cart = cartRepository.FindCartByUserId(userId);
        return cart != null ? Ok(cart) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<CartDTO>> AddCart(CartDTO dto)
    {
        var cart = cartRepository.SaveOrUpdateCart(dto);
        return cart != null ? Ok(cart) : NotFound();
    }

    [HttpPut]
    public async Task<ActionResult<CartDTO>> UpdateCart(CartDTO dto)
    {
        var cart = cartRepository.SaveOrUpdateCart(dto);
        return cart != null ? Ok(cart) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<CartDTO>> RemoveCart(int cartDetailId)
    {
        var result = cartRepository.RemoveFromCart(cartDetailId);
        return result ? Ok() : BadRequest();
    }
}
