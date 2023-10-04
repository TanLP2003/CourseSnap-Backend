using Discount.Application.Models;
using Discount.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/Discount/Coupon")]
    [ApiController]
    public class CouponController : ControllerBase
    {
        private readonly IServiceManager _service;

        public CouponController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetCoupon")]
        public async Task<IActionResult> GetCoupon([FromQuery] string courseName, [FromQuery] string code)
        {
            var coupon = await _service.Coupon.GetCouponByNameAndCode(courseName, code);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<IActionResult> CreatCoupon([FromBody] CouponModel couponModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var newCoupon = await _service.Coupon.CreateCoupon(couponModel);
            return CreatedAtAction("GetCoupon", new { courseName = couponModel.CourseName, code = newCoupon.Code }, newCoupon);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCoupon([FromBody] CouponModel couponModel)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            await _service.Coupon.UpdateCoupon(couponModel);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon([FromQuery] string courseName, [FromQuery] string code)
        {
            await _service.Coupon.DeleteCoupon(courseName, code);
            return NoContent();
        }
    }
}
