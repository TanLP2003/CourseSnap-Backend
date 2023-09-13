using AutoMapper;
using Payment.Application.Models;
using Payment.Domain.Entities;
using ServiceBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Application.Mapping
{
    public class BillProfile : Profile
    {
        public BillProfile()
        {
            CreateMap<CheckoutEvent, Bill>()
                .ForMember(des => des.TransactionTime, opt => opt.MapFrom(src => DateTime.Today.ToString("dd/MM/yyyy")));
            CreateMap<Bill, BillModel>();
            CreateMap<CartItemModel, CartItem>().ReverseMap();
            CreateMap<CheckoutItemEvent, CartItem>();
        }
    }
}
