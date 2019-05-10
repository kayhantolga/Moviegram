namespace Moviegram.Common.Utilities
{
    public static class ThumbnailHelper
    {
        /// <summary>
        /// Get thumbnail of picture. THis method only work with placeholder.com/1024x1024
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string ToThumbnail(this string url)
        {
            return url.Replace("https://via.placeholder.com/1024x1024", "https://via.placeholder.com/128x128");
        }
    }
}
