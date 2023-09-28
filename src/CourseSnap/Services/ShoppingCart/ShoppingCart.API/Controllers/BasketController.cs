using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.API.Grpc;
using ShoppingCart.Application.Models;
using ShoppingCart.Application.Models.Checkout;
using ShoppingCart.Application.Services;

namespace ShoppingCart.API.Controllers
{
    [Route("api/Basket")]
    [ApiController]
    [Authorize]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _services;
        private readonly GrpcConsumer _grpcConsumer;
        private readonly IPublishEndpoint _publishEndpoint;
        public BasketController(IBasketService basketService, GrpcConsumer grpcConsumer, IPublishEndpoint publishEndpoint) 
        {
            _services = basketService;  
            _grpcConsumer = grpcConsumer;
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet("{userName}", Name ="GetBasket")]
        public async Task<IActionResult> GetBasket(string userName)
        {
            var result = await _services.GetBasket(userName);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBasket([FromBody] BasketWriteModel model)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            foreach (var basketItem in model.Items)
            {
                var discount = await _grpcConsumer.GetDiscount(basketItem.CourseName, basketItem.Code, basketItem.Category);
                basketItem.Cost -= discount;
            }
            
            var basketResponse = await _services.UpdateBasket(model);
            
            return CreatedAtAction("GetBasket", new {userName = basketResponse.UserName}, basketResponse);
        }

        [HttpDelete("{userName}")]
        public async Task<IActionResult> DeleteBasket(string userName)
        {
            await _services.DeleteBasket(userName);
            return NoContent();
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] BasketCheckout basketCheckout)
        {
            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }
            var checkoutEvent = await _services.Checkout(basketCheckout);
            await _publishEndpoint.Publish(checkoutEvent);
            return Ok();
        }
    }
}
