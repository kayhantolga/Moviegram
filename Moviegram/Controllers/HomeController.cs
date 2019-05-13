using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moviegram.Application.Exceptions;
using Moviegram.Domain.Exceptions;

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
        public IActionResult GetDetailInformation()
        {
            return Ok("pong");
        }

        /// <summary>
        ///    Generate a sample exception response
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SampleException")]
        [ProducesResponseType(typeof(MoviegramException), 200)]
        public IActionResult GetSampleException()
        {
            throw StaticExceptions.AppServerErrors.SomeThingWrong;
        }
    }
}