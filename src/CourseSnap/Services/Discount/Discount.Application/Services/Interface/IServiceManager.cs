using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Services.Interface
{
    public interface IServiceManager
    {
        ICouponService Coupon { get; }
        ISpecSaleService SpecSale { get; }
    }
}
