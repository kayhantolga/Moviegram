using System.Threading.Tasks;
using Moviegram.Common.Utilities;

namespace Moviegram.Domain.Interfaces
{
    public interface IUserStaticContext
    {
        Task InitAll();
        Task SetCursor();

        Cursor Cursor { get; set; }
    }
}
