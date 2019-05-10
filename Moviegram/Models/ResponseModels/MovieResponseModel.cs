using System;
using System.Collections.Generic;
using System.Linq;
using Moviegram.Application.Models.ViewModels;

namespace Moviegram.Models.ResponseModels
{
    public class MoviesListResponseModel
    {
        public List<MovieListResponseModel> Movies { get; set; }
    }

    public class MovieResponseModel
    {
        public MovieResponseModel(MovieViewModel movieView) 
        {
            Genre = movieView.Genre;
            Id = movieView.Id;
            Poster = movieView.Poster;
            Title = movieView.Title;
            MovieShowTimes = movieView.MovieShowTimes.Select(r => new MovieShowTimeResponseModel(r));
            Actors = movieView.Actors.Select(r => new CelebrityResponseModel(r));
        }

        public string Genre { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public IEnumerable<MovieShowTimeResponseModel> MovieShowTimes { get; set; }
        public IEnumerable<CelebrityResponseModel> Actors { get; set; }
    }

    public class MovieListResponseModel
    {
        public MovieListResponseModel(MovieListViewModel movieView)
        {
            Id = movieView.Id;
            Poster = movieView.Poster;
            Title = movieView.Title;
            MovieShowTimes = movieView.MovieShowTimes.Select(r => new MovieShowTimeResponseModel(r));
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public IEnumerable<MovieShowTimeResponseModel> MovieShowTimes { get; set; }
    }
}