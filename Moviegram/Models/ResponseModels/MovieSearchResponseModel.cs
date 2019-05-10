using System.Collections.Generic;
using System.Linq;
using Moviegram.Application.Models.ViewModels;

namespace Moviegram.Models.ResponseModels
{
    public class MovieSearchResponseModel
    {
        public MovieSearchResponseModel(MovieSearchListViewModel  model)
        {
            SearchDepth = model.SearchDepth;
            Title = model.Title;
            Movies = model.Movies.Select(r => new MovieListResponseModel(r)).ToList();
        }
        public int? SearchDepth { get; set; }
        public string Title { get; set; }
        public List<MovieListResponseModel> Movies { get; set; }
    }
}
