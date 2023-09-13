using MassTransit;
using Payment.Application.EventConsumer;
using ServiceBus;

namespace Payment.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureMessageBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<CheckoutEventConsumer>();
                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(configuration.GetSection("RabbitmqUrl")["HostAddress"]);
                    config.ReceiveEndpoint(EventQueues.CheckoutEventQueue, c =>
                    {
                        c.ConfigureConsumer<CheckoutEventConsumer>(context);
                    });
                });
            });

            services.AddScoped<CheckoutEventConsumer>();
        }
    }
}
