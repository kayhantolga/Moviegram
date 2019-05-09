using Microsoft.EntityFrameworkCore;
using Moviegram.Persistence.DbContext;

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