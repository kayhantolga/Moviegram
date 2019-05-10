using System.Threading.Tasks;
using Moviegram.Common.Utilities;
using Moviegram.Persistence.DbContexts;

namespace Moviegram.Application.Configurations
{
    /// <summary>
    /// User static variables per request
    /// </summary>
    public interface IUserStaticContext
    {
        Task InitAll();
        /// <summary>
        /// Set general cursor for this request 
        /// </summary>
        /// <returns></returns>
        Task SetCursor();
        /// <summary>
        /// Set database for this request
        /// </summary>
        /// <returns></returns>
        Task SetDb();

        Cursor Cursor { get; set; }
        MoviegramDbContext Db { get; set; }
    }
}
