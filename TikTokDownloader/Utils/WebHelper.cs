using System.Web;
using TikTokDownloader.Models;

namespace TikTokDownloader.Utils
{
    public static class WebHelper
    {
        private static readonly HttpClient httpClient = new();
        public static Media? GetMediaInfo(string url)
        {
            try
            {
                var content = httpClient.GetStringAsync(url).Result;
                var labelA = "<title data-react-helmet=\"true\">";
                var labelB = "<span class=\"CE7XkkTw\">";
                var labelC = "src%22%3A%22%2F%2F";
                var labelNickTail = "</span></span></span></span></span></div></a><p class=\"yibO9njB\">";
                var stopLbl = "[\"src-layouts-index\",\"src-pages-Video-id\"]}</script>";
                content = content[(content.IndexOf(labelA) + labelA.Length)..content.IndexOf(stopLbl)];
                var mediaInfo = new Media();
                mediaInfo.Title = content[..content.IndexOf(" - 抖音</title>")];
                content = content[(content.IndexOf(labelB) + labelB.Length)..];
                mediaInfo.Like = content[..content.IndexOf("</span>")];
                content = content[(content.IndexOf(labelB) + labelB.Length)..];
                mediaInfo.CommentCnt = content[..content.IndexOf("</span>")];
                content = content[(content.IndexOf(labelB) + labelB.Length)..];
                mediaInfo.CollectCnt = content[..content.IndexOf("</span>")];
                var nickSubContent = content[..content.IndexOf(labelNickTail)];
                mediaInfo.NickName = nickSubContent[(nickSubContent.LastIndexOf("<span>") + 6)..];
                content = content[(content.IndexOf(labelC) + labelC.Length)..];
                mediaInfo.MediaURL = content[..(content.IndexOf("vr%3D") + 5)];
                mediaInfo.MediaURL = $"https://{HttpUtility.UrlDecode(mediaInfo.MediaURL)}";
                return mediaInfo;
            }
            catch
            {
                return null;
            }
        }
    }
}
