using System.Linq;
using Moviegram.Domain.Entities;

namespace Moviegram.Application.Filters
{
    /// <summary>
    ///     Filters for movies
    /// </summary>
    public static class MovieFilters
    {
        /// <summary>
        ///     Filter movies by actor which they include the given keyword.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword">Search keyword</param>
        /// <returns></returns>
        public static IQueryable<Movie> FilterByActorNameInclude(this IQueryable<Movie> source, string keyword)
        {
            return string.IsNullOrEmpty(keyword)
                ? Enumerable.Empty<Movie>().AsQueryable()
                : source.Where(r => r.Actors.Any(a => a.Celebrity.Name.Contains(keyword)));
        }

        /// <summary>
        ///     Filter movies by genre which they include the given keyword.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword">Search keyword</param>
        /// <returns></returns>
        public static IQueryable<Movie> FilterByGenreInclude(this IQueryable<Movie> source, string keyword)
        {
            return string.IsNullOrEmpty(keyword)
                ? Enumerable.Empty<Movie>().AsQueryable()
                : source.Where(r => r.Genre.Contains(keyword));
        }

        /// <summary>
        ///     Filter movies by title which they include the given keyword.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword">Search keyword</param>
        /// <returns></returns>
        public static IQueryable<Movie> FilterByTitleInclude(this IQueryable<Movie> source, string keyword)
        {
            return string.IsNullOrEmpty(keyword)
                ? Enumerable.Empty<Movie>().AsQueryable()
                : source.Where(r => r.Title.Contains(keyword));
        }

        /// <summary>
        ///     Filter movies by title which they start with the given keyword.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="keyword">Search keyword</param>
        /// <returns></returns>
        public static IQueryable<Movie> FilterByTitleStartsWith(this IQueryable<Movie> source, string keyword)
        {
            return string.IsNullOrEmpty(keyword)
                ? Enumerable.Empty<Movie>().AsQueryable()
                : source.Where(r => r.Title.StartsWith(keyword));
        }
    }
}