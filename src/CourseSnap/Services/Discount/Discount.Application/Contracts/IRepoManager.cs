using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Contracts
{
    public interface IRepoManager
    {
        ICouponRepo Coupon { get; }
        ICategorySaleRepo CategorySale { get; }
        Task SaveAsync();
    }
}
