using System.Collections.Generic;
using System.Linq;
using Moviegram.Application.Models.ViewModels;

namespace Moviegram.Models.ResponseModels
{
    /// <summary>
    ///     Movie Search response model
    /// </summary>
    public class MovieSearchResponseModel
    {
        public MovieSearchResponseModel(MovieSearchListViewModel model)
        {
            if (model == null) return;

            SearchDepth = model.SearchDepth;
            Title = model.Title;
            Movies = model.Movies.Select(r => new MovieListResponseModel(r)).ToList();
        }

        /// <summary>
        ///     The state of Search process
        /// </summary>
        public int? SearchDepth { get; set; }

        /// <summary>
        ///     Information Title for search process
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Found movie results
        /// </summary>
        public List<MovieListResponseModel> Movies { get; set; }
    }
}