using Discount.Domain.Contracts;
using Discount.Infrastructure.Data;
using Discount.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IRepoManager, RepoManager>();
            services.AddDbContext<DiscountContext>(opt =>
            {
                opt.UseMySQL(configuration.GetConnectionString("MySqlConnection"));
            });
        }
    }
}
