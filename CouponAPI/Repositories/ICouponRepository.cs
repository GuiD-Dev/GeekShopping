using CouponAPI.DTO;

namespace CouponAPI.Repositories;

public interface ICouponRepository
{
    Task<CouponDTO> GetCouponByCode(string couponCode);
}