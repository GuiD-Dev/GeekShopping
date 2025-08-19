using Microsoft.AspNetCore.Mvc;
using CartAPI.Repositories;
using CartAPI.DTO;
using CartAPI.CartAPI.Messages;

namespace CartAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CartController(ICartRepository cartRepository) : ControllerBase
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

    [HttpPost("checkout")]
    public async Task<ActionResult<CheckoutDTO>> Checkout(CheckoutDTO dto)
    {
        var cart = cartRepository.FindCartByUserId(dto.UserId);
        if (cart == null) return NotFound();

        dto.Details = cart.Details;
        dto.DateTime = DateTime.Now;

        // TODO: apply RabbitMQ logic here

        return Ok(dto);
    }

}
