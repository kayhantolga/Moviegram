using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moviegram.Application.Configurations;
using Moviegram.Application.Filters;
using Moviegram.Application.Models.ViewModels;
using Moviegram.Common.Utilities;
using Moviegram.Persistence.DbContexts;

namespace Moviegram.Application.Managers
{
    public class MovieCoreManager : IMovieManager
    {
        private readonly MoviegramDbContext _db;
        private readonly IUserStaticContext _userStaticContext;

        public MovieCoreManager(IUserStaticContext userStaticContext)
        {
            _userStaticContext = userStaticContext;
            _db = _userStaticContext.Db;
        }

        public async Task<List<MovieListViewModel>> GetMovieList()
        {
            return await _db.Movies
                .OrderBy(r => r.Title)
                .GoToCursor(_userStaticContext.Cursor)
                .Select(MovieListViewModel.Projection)
                .ToListAsync();
        }

        public async Task<MovieViewModel> GetMovieDetail(Guid id)
        {
            var movie = await _db.Movies
                .Include(r => r.MovieShowTimes)
                .Include(r => r.Actors)
                .ThenInclude(r => r.Celebrity)
                .FirstOrDefaultAsync(r => r.Id == id);

            return MovieViewModel.FromEntity(movie);
        }

        public async Task<MovieSearchListViewModel> Search(string keyword)
        {
            var result = new MovieSearchListViewModel
            {
                Title = "Found Results by Title",
                SearchDepth = 0
            };

            result.Movies = await _db.Movies
                .FilterByTitleNameStartsWith(keyword)
                .OrderBy(r => r.Title)
                .GoToCursor(_userStaticContext.Cursor)
                .Select(MovieListViewModel.Projection)
                .ToListAsync();

            //If we can't find anything starts with keyword maybe it's a word in The Title
            if (!result.Movies.Any())
            {
                result.SearchDepth++;
                result.Movies = await _db.Movies
                    .FilterByTitleNameInclude(keyword)
                    .OrderBy(r => r.Title)
                    .GoToCursor(_userStaticContext.Cursor)
                    .Select(MovieListViewModel.Projection)
                    .ToListAsync();
            }

            //If we can't find anything maybe it's name of the actor
            if (!result.Movies.Any())
            {
                result.SearchDepth++;
                result.Title = "Found results by Actors";
                result.Movies = await _db.Movies
                    .FilterByActorNameInclude(keyword)
                    .OrderBy(r => r.Title)
                    .GoToCursor(_userStaticContext.Cursor)
                    .Select(MovieListViewModel.Projection)
                    .ToListAsync();
            }

            //If we can't find anything lastly we can try to find something in the genre.
            if (!result.Movies.Any())
            {
                result.SearchDepth++;
                result.Title = "Found results by Genre";
                result.Movies = await _db.Movies
                    .FilterByGenreInclude(keyword)
                    .OrderBy(r => r.Title)
                    .GoToCursor(_userStaticContext.Cursor)
                    .Select(MovieListViewModel.Projection)
                    .ToListAsync();
            }

            if (!result.Movies.Any())
            {
                result.SearchDepth++;
                result.Title = "Sorry, nothing found ¯\\_(ツ)_/¯";
            }

            return result;
        }
    }
}