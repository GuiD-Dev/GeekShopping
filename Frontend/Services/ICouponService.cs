using Frontend.ViewModels;

namespace Frontend.Services;

public interface ICouponService
{
    Task<CouponViewModel> GetCoupon(string code);
}