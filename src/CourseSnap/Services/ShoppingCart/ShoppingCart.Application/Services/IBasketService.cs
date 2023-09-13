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
        Task<BasketReturnModel> GetBasket(Guid userId);
        Task<BasketReturnModel> UpdateBasket(BasketWriteModel model);
        Task DeleteBasket(Guid userId);
        Task<CheckoutEvent> Checkout(BasketCheckout basketCheckout);
    }
}
