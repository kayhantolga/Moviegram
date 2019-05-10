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

    /// <summary>
    ///     All data about Movie
    /// </summary>
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

        /// <summary>
        ///     Genre of Movie
        /// </summary>
        public string Genre { get; set; }

        public Guid Id { get; set; }

        /// <summary>
        ///     Title of Movie
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Full Sized (1024x1024) image url of Movie
        /// </summary>
        public string Poster { get; set; }

        /// <summary>
        ///     Show times of Movie
        /// </summary>
        public IEnumerable<MovieShowTimeResponseModel> MovieShowTimes { get; set; }

        /// <summary>
        ///     Actors of Movie
        /// </summary>
        public IEnumerable<CelebrityResponseModel> Actors { get; set; }
    }

    /// <summary>
    ///     Movie data model for list
    ///     Summarized for lists
    /// </summary>
    public class MovieListResponseModel
    {
        public MovieListResponseModel(MovieListViewModel movieView)
        {
            Id = movieView.Id;
            Poster = movieView.Poster;
            Title = movieView.Title;
            MovieShowTimes = movieView.MovieShowTimes.Select(r => new MovieShowTimeResponseModel(r));
        }

        /// <summary>
        ///     Id of Movie
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        ///     Title of Movie
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Thumb (128x128) image url of Movie
        /// </summary>
        public string Poster { get; set; }

        /// <summary>
        ///     Show times of Movie
        /// </summary>
        public IEnumerable<MovieShowTimeResponseModel> MovieShowTimes { get; set; }
    }
}