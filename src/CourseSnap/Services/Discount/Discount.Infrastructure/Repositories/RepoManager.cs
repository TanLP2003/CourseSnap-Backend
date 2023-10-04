using Discount.Application.Contracts;
using Discount.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure.Repositories
{
    public class RepoManager : IRepoManager
    {
        private readonly DiscountContext _context;
        private readonly Lazy<ICouponRepo> _couponRepo;
        private readonly Lazy<ICategorySaleRepo> _categorySaleRepo;

        public RepoManager(DiscountContext context, IConfiguration configuration)
        {
            _context = context;
            _couponRepo = new Lazy<ICouponRepo>(() => new CouponRepo(_context, configuration));
            _categorySaleRepo = new Lazy<ICategorySaleRepo>(() => new CategorySaleRepo(_context, configuration));
        }

        public ICouponRepo Coupon => _couponRepo.Value;
        public ICategorySaleRepo CategorySale=> _categorySaleRepo.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
