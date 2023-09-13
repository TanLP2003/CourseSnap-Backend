using ShoppingCart.Domain.Contracts;
using ShoppingCart.Domain.Entities;
using StackExchange.Redis;
using System.Text.Json;


namespace ShoppingCart.Infrastructure.Repositories
{
    public class BasketRepo : IBasketRepo
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase _database;

        public BasketRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _database = _redis.GetDatabase();
        }

        public async Task<Basket> GetBasket(Guid id)
        {
            var basket = await _database.StringGetAsync(id.ToString());
            
            if (basket.IsNull)
            {
                return new Basket
                {
                    UserId = id,
                    Items = new List<BasketItem>(),
                };
            }

            return JsonSerializer.Deserialize<Basket>(basket);
        }

        public async Task UpdateBasket(Basket basket)
        {
            var serialObj = JsonSerializer.Serialize(basket);
            await _database.StringSetAsync(basket.UserId.ToString(), serialObj);   
        }

        public async Task DeleteBasket(Guid userId) => await _database.KeyDeleteAsync(userId.ToString());
    }
}
