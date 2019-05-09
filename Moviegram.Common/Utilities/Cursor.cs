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
    }
}