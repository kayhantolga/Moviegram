using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moviegram.Application.Configurations;
using Moviegram.Application.Models.ViewModels;
using Moviegram.Persistence.DbContexts;

namespace Moviegram.Application.Managers
{
    public class MovieCoreManager
    {
        private readonly IUserStaticContext _userStaticContext;
        private readonly MoviegramDbContext _db;

        public MovieCoreManager(IUserStaticContext userStaticContext)
        {
            _userStaticContext = userStaticContext;
            _db = _userStaticContext.Db;
        }
        public async Task<List<MovieListViewModel>> GetMovieList()
        {
            return await _db.Movies.Select(MovieListViewModel.Projection).ToListAsync();
        }

        public async Task<MovieViewModel> GetMovieDetail(Guid id)
        {

            var movie = MovieViewModel.FromEntity(await _db.Movies.FirstOrDefaultAsync(r => r.Id == id));
            return movie;
        }
    }
}