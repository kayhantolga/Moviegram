using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moviegram.Application.Configurations;

namespace Moviegram.Controllers
{
    public class BaseController : ControllerBase
    {

        private IUserStaticContext _userStaticContext;

        protected IUserStaticContext UserStaticContext => _userStaticContext ??
                                                          (_userStaticContext = HttpContext.RequestServices
                                                              .GetService<IUserStaticContext>());
    }
}
