using Discount.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
