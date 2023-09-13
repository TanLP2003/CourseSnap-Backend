using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discount.Application.Services;
using Discount.Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
namespace Discount.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IServiceManager, ServiceManager>();
        }
    }
}
