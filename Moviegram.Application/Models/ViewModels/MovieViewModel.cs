using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Moviegram.Common.Utilities;
using Moviegram.Domain.Entities;

namespace Moviegram.Application.Models.ViewModels
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Poster { get; set; }
        public  IEnumerable<MovieShowTimeViewModel> MovieShowTimes { get; set; }
        public static Expression<Func<Movie, MovieViewModel>> Projection
        {
            get
            {
                return item => new MovieViewModel()
                {
                    Id = item.Id,
                    Genre = item.Genre,
                    Poster = item.Poster,
                    Title = item.Title,
                    MovieShowTimes = item.MovieShowTimes.AsQueryable().OrderBy(r=>r.ShowTimeStart).Select(MovieShowTimeViewModel.Projection)
                };
            }
        }

        public static MovieViewModel FromEntity(Movie entity)
        {
            return entity == null ? new MovieViewModel() : Projection.Compile().Invoke(entity);
        }
    }

    public class MovieListViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public IEnumerable<MovieShowTimeViewModel> MovieShowTimes { get; set; }
        public static Expression<Func<Movie, MovieListViewModel>> Projection
        {
            get
            {
                return item => new MovieListViewModel()
                {
                    Id = item.Id,
                    Poster = item.Poster.ToThumbnail(),
                    Title = item.Title,
                    MovieShowTimes = item.MovieShowTimes.AsQueryable().OrderBy(r => r.ShowTimeStart).Select(MovieShowTimeViewModel.Projection)
                };
            }
        }

        public static MovieListViewModel FromEntity(Movie entity)
        {
            return entity == null ? new MovieListViewModel() : Projection.Compile().Invoke(entity);
        }
    }
}