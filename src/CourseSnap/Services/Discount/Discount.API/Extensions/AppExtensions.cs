﻿        using Microsoft.EntityFrameworkCore;

namespace Discount.API.Extensions
{
    public static class AppExtensions
    {
        public static void MigrateDb<TContext>(this WebApplication app, int retry = 0)
            where TContext : DbContext
        {
            using (var scope = app.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var context = service.GetRequiredService<TContext>();
                //var logger = service.GetRequiredService<ILogger>();
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    if (retry <= 50)
                    {
                        app.MigrateDb<TContext>(retry + 1);
                    }
                }
                //logger.LogInformation("Migrate Database success");
            }
        }
    }
}
