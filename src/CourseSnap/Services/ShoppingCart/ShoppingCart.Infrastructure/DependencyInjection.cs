using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoppingCart.Application.Contracts;
using ShoppingCart.Infrastructure.Repositories;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<IConnectionMultiplexer>(opt =>
                    ConnectionMultiplexer.Connect(configuration.GetSection("RedisSettings")["ConnectionString"]));

            services.AddScoped<IBasketRepo, BasketRepo>();
        }
    }
}
