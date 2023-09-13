using AutoMapper;
using ServiceBus.Events;
using ShoppingCart.Application.Models;
using ShoppingCart.Application.Models.Checkout;
using ShoppingCart.Domain.Contracts;
using ShoppingCart.Domain.Entities;
using ShoppingCart.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Application.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepo _repo;
        private readonly IMapper _mapper;

        public BasketService(IBasketRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BasketReturnModel> GetBasket(Guid userId)
        {
            var basket = await _repo.GetBasket(userId);
            return _mapper.Map<BasketReturnModel>(basket);  
        }

        public async Task<BasketReturnModel> UpdateBasket(BasketWriteModel model)
        {
            var basket = _mapper.Map<Basket>(model);
            await _repo.UpdateBasket(basket);
            return _mapper.Map<BasketReturnModel>(basket);
        }

        public async Task DeleteBasket(Guid userId)
        {
            await _repo.DeleteBasket(userId);   
        }

        public async Task<CheckoutEvent> Checkout(BasketCheckout basketCheckout)
        {
            var basket = await _repo.GetBasket(basketCheckout.UserId);
            if (basket == null)
            {
                throw new NotFoundException("Basket does not exist"); 
            }
            basketCheckout.TotalCost = basket.TotalCost;
            basketCheckout.Tax = Convert.ToInt32(basketCheckout.TotalCost * 0.05);
            basketCheckout.FinalCost = basketCheckout.TotalCost + basketCheckout.Tax;

            basketCheckout.CartDescription = new List<BasketCheckoutItem>();
            foreach (var item in basket.Items)
            {
                basketCheckout.CartDescription.Add(new BasketCheckoutItem
                {
                    CourseName = item.CourseName,
                    Cost = item.Cost
                });
            }

            var checkoutEvent = _mapper.Map<CheckoutEvent>(basketCheckout);
            await _repo.DeleteBasket(basketCheckout.UserId);
            return checkoutEvent;
        }
    }
}
