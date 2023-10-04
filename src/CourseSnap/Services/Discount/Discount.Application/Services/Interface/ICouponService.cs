using Discount.Application.Models;

namespace Discount.Application.Services.Interface
{
    public interface ICouponService
    {
        Task<CouponModel> GetCouponByNameAndCode(string couponName, string code);
        Task<CouponModel> CreateCoupon(CouponModel coupon);
        Task UpdateCoupon(CouponModel coupon);
        Task DeleteCoupon(string courseName, string code);
    }
}