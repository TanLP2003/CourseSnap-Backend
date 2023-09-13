using Microsoft.Extensions.DependencyInjection;
using Product.Domain.Contracts;
using Product.Infrastructure.Data;
using Product.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseContext, CourseContext>();
            services.AddScoped<ICourseRepo, CourseRepo>();
        }
    }
}
