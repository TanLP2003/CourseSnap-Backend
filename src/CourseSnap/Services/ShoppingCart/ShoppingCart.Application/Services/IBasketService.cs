using ServiceBus.Events;
using ShoppingCart.Application.Models;
using ShoppingCart.Application.Models.Checkout;
using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Services
{
    public interface IBasketService
    {
        Task<BasketReturnModel> GetBasket(string userName);
        Task<BasketReturnModel> UpdateBasket(BasketWriteModel model);
        Task DeleteBasket(string userName);
        Task<CheckoutEvent> Checkout(BasketCheckout basketCheckout);
    }
}
