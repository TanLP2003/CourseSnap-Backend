using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Contracts
{
    public interface IRepoManager
    {
        ICouponRepo Coupon { get; }
        ISpecSaleRepo SpecSale { get; }
        Task SaveAsync();
    }
}
