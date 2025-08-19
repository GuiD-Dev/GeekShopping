using CouponAPI.DTO;
using CouponAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CouponAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class CouponController(ICouponRepository couponRepository) : ControllerBase
{
    [HttpGet("{couponCode}")]
    public async Task<ActionResult<CouponDTO>> GetCouponByCode(string couponCode)
    {
        var coupon = await couponRepository.GetCouponByCode(couponCode);
        return coupon != null ? Ok(coupon) : NotFound();
    }
}
