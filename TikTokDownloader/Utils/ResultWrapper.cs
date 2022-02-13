namespace TikTokDownloader.Utils
{
    public class ResultWrapper
    {
        public int Code { get; set; }
        public string Message { get; set; } = "";
        public dynamic? Data { get; set; } = null;
        public long Count { get; set; }
    }
}
