using AutoMapper;
using Discount.Application.Contracts;
using Discount.Application.Services.Interface;
using Microsoft.Extensions.Logging;

namespace Discount.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICouponService> _couponService;
        private readonly Lazy<ICategorySaleService> _categorySaleService;
        private readonly IMapper _mapper;

        public ServiceManager(IRepoManager repoManager, IMapper mapper, ILogger<ServiceManager> logger)
        {
            _couponService = new Lazy<ICouponService>(() => new CouponService(repoManager, mapper));
            _categorySaleService = new Lazy<ICategorySaleService>(() => new CategorySaleService(repoManager, mapper));
        }

        public ICouponService Coupon => _couponService.Value;

        public ICategorySaleService CategorySale => _categorySaleService.Value;
    }
}