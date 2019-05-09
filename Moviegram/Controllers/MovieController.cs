using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moviegram.Managers;
using Moviegram.Models.ResponseModels;
using Moviegram.Persistence.DbContexts;

namespace Moviegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly MoviegramDbContext _db;

        public MovieController(MoviegramDbContext db)
        {
            _db = db;
        }

        
        [HttpGet, Route("Movies"), ProducesResponseType(typeof(MoviesListResponseModel), 200)]
        public async Task<IActionResult> GetMovies()
        {
            var movieManager = new MovieManager(_db);
            var result = new MoviesListResponseModel()
            {
                Movies = (await movieManager.GetMovieList()).Select(r => new MovieListResponseModel(r)).ToList()
            };
            
            return Ok(result);
        }
    }
}