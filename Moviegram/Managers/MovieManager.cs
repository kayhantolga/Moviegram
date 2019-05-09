using Moviegram.Application.Managers;
using Moviegram.Persistence.DbContexts;

namespace Moviegram.Managers
{
    public class MovieManager:MovieCoreManager
    {
        public MovieManager(MoviegramDbContext db) : base(db)
        {
        }
    }
}
