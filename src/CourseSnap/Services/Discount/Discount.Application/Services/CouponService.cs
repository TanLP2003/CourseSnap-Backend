using AutoMapper;
using Discount.Application.Contracts;
using Discount.Application.Models;
using Discount.Application.Services.Interface;
using Discount.Domain.Entities;
using Discount.Domain.Exceptions;

namespace Discount.Application.Services
{
    public class CouponService : ICouponService
    {
        private readonly IRepoManager _repo;
        private readonly IMapper _mapper;

        public CouponService(IRepoManager repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CouponModel> GetCouponByNameAndCode(string couponName, string code)
        {
            var coupon = await _repo.Coupon.GetByNameAndCode(couponName, code);
            return _mapper.Map<CouponModel>(coupon);
        }

        public async Task<CouponModel> CreateCoupon(CouponModel couponModel)
        {
            var result = await _repo.Coupon.CodeExisted(couponModel.Code);
            if (result)
            {
                throw new BadRequestException($"Code : {couponModel.Code} already existed");
            }
            var coupon = _mapper.Map<Coupon>(couponModel);
            _repo.Coupon.Create(coupon);
            await _repo.SaveAsync();

            return couponModel;
        }

        public async Task DeleteCoupon(string courseName, string code)
        {
            var coupon = await _repo.Coupon.GetByNameAndCode(courseName, code);

            if (coupon == null)
            {
                throw new NotFoundException($"Coupon with name : {courseName} and code: {code} doesn't exist");
            }
            _repo.Coupon.Delete(coupon);
            await _repo.SaveAsync();    
        }

        public async Task UpdateCoupon(CouponModel couponModel)
        {
            var coupon = await _repo.Coupon.GetByNameAndCode(couponModel.CourseName, couponModel.Code);

            if (coupon == null)
            {
                throw new NotFoundException($"Coupon with name : {couponModel.CourseName} and code: {couponModel.Code} doesn't exist");
            }

            _mapper.Map(couponModel, coupon);
            _repo.Coupon.Update(coupon);
            await _repo.SaveAsync();
        }
    }
}