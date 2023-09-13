using Discount.Domain.Contracts;
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
        private readonly Lazy<ISpecSaleRepo> _specSaleRepo;

        public RepoManager(DiscountContext context, IConfiguration configuration)
        {
            _context = context;
            _couponRepo = new Lazy<ICouponRepo>(() => new CouponRepo(_context, configuration));
            _specSaleRepo = new Lazy<ISpecSaleRepo>(() => new SpecSaleRepo(_context, configuration));
        }

        public ICouponRepo Coupon => _couponRepo.Value;
        public ISpecSaleRepo SpecSale=> _specSaleRepo.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
