using Discount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Contracts
{
    public interface ICouponRepo : IBaseRepo<Coupon>
    {
        Task<bool> CheckCourseName(string courseName);
        Task<Coupon> GetByNameAndCode(string courseName, string code);
        Task<bool> CodeExisted(string code);
    }
}
