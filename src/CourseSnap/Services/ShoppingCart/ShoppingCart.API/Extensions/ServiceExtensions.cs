using ShoppingCart.Infrastructure;
using ShoppingCart.Application;
using GrpcServer.Protos;
using ShoppingCart.API.Grpc;
using Microsoft.AspNetCore.Mvc;
using MassTransit;

namespace ShoppingCart.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddServiceDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddInfrastructureServices(configuration);
            services.AddApplicationServices(configuration);
            services.AddGrpcClient<GrpcDiscountService.GrpcDiscountServiceClient>(opt =>
            {
                opt.Address = new Uri(configuration.GetSection("DiscountUrl")["GrpcServer"]);
            });

            services.AddScoped<GrpcConsumer>();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(configuration.GetSection("RabbitmqUrl")["HostAddress"]);
                });
            });
        }
    }
}
