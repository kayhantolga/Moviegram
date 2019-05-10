using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moviegram.Application.Models.ViewModels;

namespace Moviegram.Application.Managers
{
    public interface IMovieManager
    {
        Task<List<MovieListViewModel>> GetMovieList();
        Task<MovieViewModel> GetMovieDetail(Guid id);
    }
}