using AutoMapper;
using Discount.Application.Models;
using Discount.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Mapping
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() 
        {
            CreateMap<CouponModel, Coupon>().ReverseMap();
            CreateMap<SpecialSaleModel, SpecialSale>().ReverseMap();
        }  
    }
}
