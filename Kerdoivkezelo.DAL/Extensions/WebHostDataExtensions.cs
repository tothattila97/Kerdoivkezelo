using Kerdoivkezelo.DAL.Seed;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerdoivkezelo.DAL.Extensions
{
    public static class WebHostDataExtensions
    {
        public static IWebHost SeedAdministrator(this IWebHost host) =>
             host.Scoped<AdministratorSeeder>((s, l) => s.GetRequiredService<AdministratorSeeder>().Seed().GetAwaiter().GetResult(), "Seeding adminstrator as needed");

        private static IWebHost Scoped<TLog>(this IWebHost host,
            Action<IServiceProvider, ILogger<TLog>> action, string title)
        {
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var logger = serviceProvider.GetRequiredService<ILogger<TLog>>();
                try
                {
                    action(serviceProvider, logger);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, $"An error occured during action: {title}");
                }
            }
            return host;
        }

    }
}
