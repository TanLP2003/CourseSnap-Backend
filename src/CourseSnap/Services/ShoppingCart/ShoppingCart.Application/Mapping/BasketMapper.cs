using AutoMapper;
using ServiceBus.Events;
using ShoppingCart.Application.Models;
using ShoppingCart.Application.Models.Checkout;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Mapping
{
    public class BasketMapper : Profile
    {
        public BasketMapper() 
        {
            CreateMap<BasketItem, BasketItemReturnModel>();
            CreateMap<Basket, BasketReturnModel>();
            CreateMap<BasketWriteModel, Basket>();
            CreateMap<BasketCheckout, CheckoutEvent>();
            CreateMap<BasketCheckoutItem, CheckoutItemEvent>();
        }
    }
}
