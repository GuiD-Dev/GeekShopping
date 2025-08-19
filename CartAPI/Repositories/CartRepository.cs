using AutoMapper;
using CartAPI.DBContext;
using CartAPI.DTO;
using CartAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CartAPI.Repositories;

public class CartRepository(MySQLContext context, IMapper mapper) : ICartRepository
{
    public CartDTO FindCartByUserId(string userId)
    {
        var cart = context.Carts.Include(c => c.Details).ThenInclude(d => d.Product)
                            .FirstOrDefault(c => c.UserId == userId);
        return mapper.Map<CartDTO>(cart);
    }

    public CartDTO SaveOrUpdateCart(CartDTO cartDto)
    {
        var cart = context.Carts.Include(c => c.Details).ThenInclude(d => d.Product)
                        .FirstOrDefault(c => c.UserId == cartDto.UserId);

        if (cart == null)
        {
            cart = mapper.Map<Cart>(cartDto);
            context.Carts.Add(cart);
        }
        else
        {
            foreach (var detailDto in cartDto.Details)
            {
                var detail = context.CartDetails.FirstOrDefault(d => d.Cart.Id == cart.Id && d.Product.Id == detailDto.Product.Id);
                if (detail == null)
                {
                    detail = mapper.Map<CartDetail>(detailDto);
                    context.CartDetails.Add(detail);
                }
                else
                {
                    detail.Count = detailDto.Count;
                    context.CartDetails.Update(detail);
                }
            }
        }

        context.SaveChanges();

        return mapper.Map<CartDTO>(cart);
    }

    public bool RemoveFromCart(long cartDetailId)
    {
        try
        {
            var detail = context.CartDetails.FirstOrDefault(c => c.Id == cartDetailId);
            if (detail == null) return false;

            var detailsCount = detail.Cart.Details.Count();

            context.CartDetails.Remove(detail);

            if (detailsCount == 1)
                context.Carts.Remove(detail.Cart);

            context.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool ClearCart(string userId)
    {
        try
        {
            var cart = context.Carts.FirstOrDefault(c => c.UserId == userId);
            if (cart == null) return false;

            var details = context.CartDetails.Where(c => c.Cart.Id == cart.Id).ToList();
            context.CartDetails.RemoveRange(details);
            context.Carts.Remove(cart);
            context.SaveChanges();

            return true;
        }
        catch
        {
            return false;
        }
    }

    public Task<bool> ApplyCoupon(string userId, string couponCode)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveCoupon(string userId)
    {
        throw new NotImplementedException();
    }
}