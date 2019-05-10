using System.Collections.Generic;

namespace Moviegram.Application.Models.ViewModels
{
    public class MovieSearchListViewModel
    {
        public int? SearchDepth { get; set; }
        public string Title { get; set; }
        public List<MovieListViewModel> Movies { get; set; }
    }
}
