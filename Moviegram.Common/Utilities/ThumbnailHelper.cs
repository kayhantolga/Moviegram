namespace Moviegram.Common.Utilities
{
    public static class ThumbnailHelper
    {
        public static string ToThumbnail(this string url)
        {
            return url.Replace("https://via.placeholder.com/1024x1024", "https://via.placeholder.com/128x128");
        }
    }
}
