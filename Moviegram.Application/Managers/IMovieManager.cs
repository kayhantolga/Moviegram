using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moviegram.Application.Models.ViewModels;

namespace Moviegram.Application.Managers
{
    public interface IMovieManager
    {
        /// <summary>
        ///     Get details of movie
        /// </summary>
        /// <param name="id">Movie Id</param>
        /// <returns></returns>
        Task<MovieViewModel> GetMovieDetail(Guid id);

        /// <summary>
        ///     Get movies
        /// </summary>
        /// <returns></returns>
        Task<List<MovieListViewModel>> GetMovieList();

        /// <summary>
        ///     Search movies
        /// </summary>
        /// <param name="keyword">Search keyword</param>
        /// <returns></returns>
        Task<MovieSearchListViewModel> Search(string keyword);
    }
}