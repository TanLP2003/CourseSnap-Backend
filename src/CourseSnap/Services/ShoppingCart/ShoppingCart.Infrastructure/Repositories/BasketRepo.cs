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

        public async Task<Basket> GetBasket(string userName)
        {
            var basket = await _database.StringGetAsync(userName);
            
            if (basket.IsNull)
            {
                return new Basket
                {
                    UserName = userName,
                    Items = new List<BasketItem>(),
                };
            }

            return JsonSerializer.Deserialize<Basket>(basket);
        }

        public async Task UpdateBasket(Basket basket)
        {
            var serialObj = JsonSerializer.Serialize(basket);
            await _database.StringSetAsync(basket.UserName, serialObj);   
        }

        public async Task DeleteBasket(string userName) => await _database.KeyDeleteAsync(userName);
    }
}
