using AutoMapper;
using Discount.Application.Services.Interface;
using Discount.Domain.Contracts;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICouponService> _couponService;
        private readonly Lazy<ISpecSaleService> _specSaleService;
        private readonly IMapper _mapper;

        public ServiceManager(IRepoManager repoManager, IMapper mapper, ILogger<ServiceManager> logger)
        {
            _couponService = new Lazy<ICouponService>(() => new CouponService(repoManager, mapper));
            _specSaleService = new Lazy<ISpecSaleService>(() => new SpecSaleService(repoManager, mapper));
        }

        public ICouponService Coupon => _couponService.Value;

        public ISpecSaleService SpecSale => _specSaleService.Value;
    }
}
