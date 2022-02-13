using Microsoft.AspNetCore.Mvc;
using TikTokDownloader.Models;
using TikTokDownloader.Utils;

namespace TikTokDownloader.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MediaInfoController : ControllerBase
    {
        private readonly IMediaInfo _mediaInfo;

        public MediaInfoController(IMediaInfo mediaInfo)
        {
            _mediaInfo = mediaInfo;
        }

        [HttpGet]
        public ActionResult<ResultWrapper> Get(string raw)
        {
            if (raw == null)
            {
                return new ResultWrapper
                {
                    Code = 1,
                    Message = "非法输入",
                    Count = 0
                };
            }
            Media? media = _mediaInfo.ExtractMediaInfo(raw);
            if (media == null)
            {
                return new ResultWrapper
                {
                    Code = 1,
                    Message = "查询失败",
                    Count = 0
                };
            }
            else
            {
                return new ResultWrapper
                {
                    Code = 0,
                    Message = "",
                    Data = media,
                    Count = 1
                };
            }
        }
    }
}