using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moviegram.Application.Managers;
using Moviegram.Models.ResponseModels;

namespace Moviegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieManager _movieManager;

        public MovieController(IMovieManager movieManager)
        {
            _movieManager = movieManager;
        }

        [HttpGet]
        [Route("Movies")]
        [ProducesResponseType(typeof(MoviesListResponseModel), 200)]
        public async Task<IActionResult> GetMovies()
        {
           // var movieManager = new MovieManager(UserStaticContext);
            var result = new MoviesListResponseModel
            {
                Movies = (await _movieManager.GetMovieList()).Select(r => new MovieListResponseModel(r)).ToList()
            };
     
            return Ok(result);
        }
    }
}