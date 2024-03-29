﻿using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Payment.Application.EventConsumer;
using ServiceBus;
using System.Text;

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

        public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var securityKey = configuration.GetSection("SecurityKey").ToString();
            var encodedKey = Encoding.ASCII.GetBytes(securityKey);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    //options.RequireHttpsMetadata = false;
                    //options.SaveToken = true;

                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("IS_TOKEN_EXPIRED", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(encodedKey)
                    };

                });
        }
    }
}
