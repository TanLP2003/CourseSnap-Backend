using Microsoft.EntityFrameworkCore;

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
                var logger = service.GetRequiredService<ILogger<Program>>();
                try
                {
                    context.Database.Migrate();
                    logger.LogInformation("Migrate Database success");
                }
                catch (Exception ex)
                {
                    if (retry <= 50)
                    {
                        logger.LogWarning($"Migrate Failed [{retry}]......");
                        Thread.Sleep(2000);
                        app.MigrateDb<TContext>(retry + 1);
                    }
                }
            }
        }
    }
}
