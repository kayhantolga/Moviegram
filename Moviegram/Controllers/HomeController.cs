using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Moviegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        /// <summary>
        ///     Check is service alive
        /// </summary>
        /// <returns>pong</returns>
        [HttpGet]
        [Route("ping")]
        [ProducesResponseType(typeof(string), 200)]
        public async Task<IActionResult> GetDetailInformation()
        {
            return Ok("pong");
        }
    }
}