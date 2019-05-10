using System.Linq;
using Moviegram.Domain.Entities;

namespace Moviegram.Application.Filters
{
    public static class MovieFilters
    {
        public static IQueryable<Movie> FilterByTitleNameStartsWith(this IQueryable<Movie> source, string keyword)
        {
            return string.IsNullOrEmpty(keyword)
                ? Enumerable.Empty<Movie>().AsQueryable()
                : source.Where(r => r.Title.StartsWith(keyword));
        }

        public static IQueryable<Movie> FilterByTitleNameInclude(this IQueryable<Movie> source, string keyword)
        {
            return string.IsNullOrEmpty(keyword)
                ? Enumerable.Empty<Movie>().AsQueryable()
                : source.Where(r => r.Title.Contains(keyword));
        }
    
        public static IQueryable<Movie> FilterByGenreInclude(this IQueryable<Movie> source, string keyword)
        {
            return string.IsNullOrEmpty(keyword)
                ? Enumerable.Empty<Movie>().AsQueryable()
                : source.Where(r => r.Genre.Contains(keyword));
        }

        public static IQueryable<Movie> FilterByActorNameInclude(this IQueryable<Movie> source, string keyword)
        {
            return string.IsNullOrEmpty(keyword)
                ? Enumerable.Empty<Movie>().AsQueryable()
                : source.Where(r => r.Actors.Any(a=>a.Celebrity.Name.Contains(keyword)));
        }

    }
}
