using TikTokDownloader.Models;

namespace TikTokDownloader
{
    public interface IMediaInfo
    {
        public Media? ExtractMediaInfo(string rawStr);
    }
}
