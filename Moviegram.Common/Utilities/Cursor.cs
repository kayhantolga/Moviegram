using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Moviegram.Common.Utilities
{
    public class Cursor
    {
        private int? _index;
        private int? _pageSize;

        public int PageSize
        {
            get => _pageSize ?? 20;
            set => _pageSize = value;
        }

        public int Index
        {
            get => _index ?? 0;
            set => _index = value;
        }

        public string LatestItem { get; set; }
    }

    public static class CursorExtensions
    {
        /// <summary>
        /// Get current cursor from querystring.
        /// Set CursorPageSize for how many item you want to get per request
        /// Set CursorIndex for which index you want to get
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static Cursor GetCursor(this HttpRequest request)
        {
            var cursor = new Cursor();
            var ifSuccess = int.TryParse(request.Query["CursorPageSize"], out var pageSize);
            if (ifSuccess)
            {
                cursor.PageSize = pageSize;
            }
            ifSuccess = int.TryParse(request.Query["CursorIndex"], out var index);
            if (ifSuccess)
            {
                cursor.Index = index;
            }
            return cursor;
        }
        
        /// <summary>
        /// Jump to cursor index and get items
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="items"></param>
        /// <param name="cursor">Generate new cursor or get it from queryString</param>
        /// <returns></returns>
        public static IQueryable<TSource> GoToCursor<TSource>(this IQueryable<TSource> items, Cursor cursor)
        {
            return items.Skip(cursor.Index * cursor.PageSize).Take(cursor.PageSize);
        }
    }
}