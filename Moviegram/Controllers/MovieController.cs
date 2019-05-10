using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moviegram.Application.Managers;
using Moviegram.Domain.Entities;
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
        [Route("DetailInformation")]
        [ProducesResponseType(typeof(MovieResponseModel), 200)]
        public async Task<IActionResult> GetDetailInformation(Guid id)
        {
            var movieDetail = await _movieManager.GetMovieDetail(id);
            var result = new MovieResponseModel(movieDetail);

            return Ok(result);
        }

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

        [HttpGet]
        [Route("Search")]
        [ProducesResponseType(typeof(MoviesListResponseModel), 200)]
        public async Task<IActionResult> GetSearch(string keyword)
        {
            var result = new MovieSearchResponseModel(await _movieManager.Search(keyword));
            return Ok(result);
        }
    }
}