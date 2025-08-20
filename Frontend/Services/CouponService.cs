using System.Net;
using Frontend.ViewModels;
using Frontend.Utils;

namespace Frontend.Services
{
    public class CouponService(HttpClient client) : ICouponService
    {
        public const string BasePath = "api/v1/coupon";

        public async Task<CouponViewModel> GetCoupon(string code)
        {
            var response = await client.GetAsync($"{BasePath}/{code}");
            if (response.StatusCode != HttpStatusCode.OK) return new CouponViewModel();
            return await response.ReadContentAs<CouponViewModel>();
        }
    }
}
