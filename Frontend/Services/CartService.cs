using Frontend.Utils;
using Frontend.ViewModels;

namespace Frontend.Services;

public class CartService(HttpClient client) : ICartService
{
    private const string BasePath = "api/v1/cart";

    public async Task<CartViewModel> FindCartByUserId(string userId)
    {
        var response = await client.GetAsync($"{BasePath}/{userId}");
        return await response.ReadContentAs<CartViewModel>();
    }

    public async Task<CartViewModel> AddItemToCart(CartViewModel cart)
    {
        var response = await client.PostAsJson($"{BasePath}", cart);
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<CartViewModel>();
        else
            throw new Exception("Something went wrong when calling API");
    }

    public async Task<CartViewModel> UpdateCart(CartViewModel cart)
    {
        var response = await client.PutAsJson($"{BasePath}", cart);
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<CartViewModel>();
        else
            throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> RemoveFromCart(long cartId)
    {
        var response = await client.DeleteAsync($"{BasePath}/{cartId}");
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else
            throw new Exception("Something went wrong when calling API");
    }

    public Task<bool> ClearCart(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> ApplyCoupon(CartViewModel cart)
    {
        var response = await client.PostAsJson($"{BasePath}/apply-coupon", cart);
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else
            throw new Exception("Something went wrong when calling API");
    }

    public async Task<bool> RemoveCoupon(string userId)
    {
        var response = await client.DeleteAsync($"{BasePath}/remove-coupon/{userId}");
        if (response.IsSuccessStatusCode)
            return await response.ReadContentAs<bool>();
        else
            throw new Exception("Something went wrong when calling API");
    }

    public Task<CartViewModel> Checkout(CartViewModel cart)
    {
        throw new NotImplementedException();
    }
}