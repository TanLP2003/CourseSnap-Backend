using AutoMapper;
using Discount.Application.Models;
using Discount.Domain.Entities;

namespace Discount.Application.Mapping
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<CouponModel, Coupon>().ReverseMap();
            CreateMap<CategorySaleModel, CategorySale>().ReverseMap();
        }  
    }
}