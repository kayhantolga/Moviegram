using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moviegram.Domain.Entities;
using Moviegram.Persistence.Extensions;

namespace Moviegram.Persistence.DbContexts
{
    public class MoviegramDbContext : DbContext
    {
        public MoviegramDbContext(DbContextOptions<MoviegramDbContext> options)
            : base(options)
        {
        }

        public MoviegramDbContext()
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Celebrity> Celebrities { get; set; }


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
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);

            }

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyAllConfigurations();
            base.OnModelCreating(builder);
        }
    }
}