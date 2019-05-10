using System.Threading.Tasks;
using Moviegram.Common.Utilities;
using Moviegram.Persistence.DbContexts;

namespace Moviegram.Application.Configurations
{
    public interface IUserStaticContext
    {
        Task InitAll();
        Task SetCursor();
        Task SetDb();

        Cursor Cursor { get; set; }
        MoviegramDbContext Db { get; set; }
    }
}
