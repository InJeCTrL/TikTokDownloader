using TikTokDownloader.Models;
using TikTokDownloader.Utils;

namespace TikTokDownloader.Services
{
    public class MediaInfo : IMediaInfo
    {
        public Media? ExtractMediaInfo(string rawStr)
        {
            var startLbl = "https://v.douyin.com";
            if (rawStr == null || !rawStr.Contains(startLbl))
            {
                return null;
            }
            var url = rawStr[rawStr.IndexOf(startLbl)..];
            url = url[..url.IndexOf(" ")];
            return WebHelper.GetMediaInfo(url);
        }
    }
}
