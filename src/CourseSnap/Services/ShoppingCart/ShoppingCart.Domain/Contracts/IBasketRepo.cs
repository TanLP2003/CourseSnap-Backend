using ShoppingCart.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Domain.Contracts
{
    public interface IBasketRepo
    {
        Task<Basket> GetBasket(Guid userId);
        Task UpdateBasket(Basket basket);
        Task DeleteBasket(Guid userId);
    }
}
