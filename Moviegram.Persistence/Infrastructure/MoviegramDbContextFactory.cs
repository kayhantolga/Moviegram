using Microsoft.EntityFrameworkCore;
using Moviegram.Persistence.DbContexts;

namespace Moviegram.Persistence.Infrastructure
{
    public class MoviegramDbContextFactory : DesignTimeDbContextFactoryBase<MoviegramDbContext>
    {
        protected override MoviegramDbContext CreateNewInstance(DbContextOptions<MoviegramDbContext> options)
        {
            return new MoviegramDbContext(options);
        }
    }
}