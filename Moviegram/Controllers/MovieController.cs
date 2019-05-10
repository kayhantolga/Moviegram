using System;
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

        /// <summary>
        /// Get detailed information about given movie Id
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns></returns>
        [HttpGet]
        [Route("DetailInformation")]
        [ProducesResponseType(typeof(MovieResponseModel), 200)]
        public async Task<IActionResult> GetDetailInformation(Guid id)
        {
            var movieDetail = await _movieManager.GetMovieDetail(id);
            var result = new MovieResponseModel(movieDetail);

            return Ok(result);
        }

        /// <summary>
        /// Get all movies ordered by Title
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Movies")]
        [ProducesResponseType(typeof(MoviesListResponseModel), 200)]
        public async Task<IActionResult> GetMovies()
        {
            var result = new MoviesListResponseModel
            {
                Movies = (await _movieManager.GetMovieList()).Select(r => new MovieListResponseModel(r)).ToList()
            };

            return Ok(result);
        }

        /// <summary>
        /// Search movies by given keyword
        /// </summary>
        /// <remarks>
        /// Search has 4 different process
        /// 0 - First it will start to find movies by title which they start with the given keyword
        /// 1 - Than it will start to find movies by title which they include the given keyword
        /// 2 - Than it will start to find movies by actor names which they include the given keyword
        /// 3 - Than it will start to find movies by genre which they include the given keyword
        /// Clients can get more results with using cursor.
        /// 4 - If result don't have any movie This means we don't have any idea what this user is looking for.
        /// Also, clients can track SearchDepth to learn about which state the results are.
        /// </remarks>
        /// <param name="keyword">Search keyword</param>
        /// <returns></returns>
        [HttpGet]
        [Route("Search")]
        [ProducesResponseType(typeof(MovieSearchResponseModel), 200)]
        public async Task<IActionResult> GetSearch(string keyword)
        {
            var result = new MovieSearchResponseModel(await _movieManager.Search(keyword));
            return Ok(result);
        }
    }
}