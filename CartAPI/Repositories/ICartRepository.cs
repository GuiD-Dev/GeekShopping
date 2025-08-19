using CartAPI.DTO;

namespace CartAPI.Repositories;

public interface ICartRepository
{
    CartDTO FindCartByUserId(string userId);
    CartDTO SaveOrUpdateCart(CartDTO dto);
    bool RemoveFromCart(long cartDetailId);
    bool ClearCart(string userId);
    Task<bool> ApplyCoupon(string userId, string couponCode);
    Task<bool> RemoveCoupon(string userId);
}