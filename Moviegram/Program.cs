using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moviegram.Application.Exceptions;
using Moviegram.Persistence.DbContexts;

namespace Moviegram
{
    public class Program
    {
        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        }

        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            StaticExceptions.Init();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = scope.ServiceProvider.GetService<MoviegramDbContext>();

                    context.Database.Migrate();
                    MoviegramDbContextInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }
    }
}