using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moviegram.Persistence.Extensions;

namespace Moviegram.Persistence.DbContext
{
    public class MoviegramDbContext : Microsoft.EntityFrameworkCore.DbContext, IDisposable
    {
        public MoviegramDbContext(DbContextOptions<MoviegramDbContext> options)
            : base(options)
        {
        }

        public MoviegramDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile("appsettings.Development.json", true)
                    .AddEnvironmentVariables()
                    .Build();
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyAllConfigurations();
            base.OnModelCreating(builder);
        }
    }
}