using Microsoft.Extensions.DependencyInjection;
using Payment.Application.Contracts;
using Payment.Infrastructure.Data;
using Payment.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payment.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IBillContext, BillContext>();
            services.AddScoped<IBillRepo, BillRepo>();
        }
    }
}
