using System.Collections.Generic;
using System.Threading.Tasks;
using YouTuber.Models;

namespace YouTuber.Service
{
    public interface IYouTubeService
    {
        IEnumerable<string> FileToList(string file);
        Task YoutubeToMp4(IEnumerable<string> urls, MediaType.MediaCodec audioCodec);
        Task<string?> YoutubeToMp4(string url, MediaType.MediaCodec audioCodec);
    }
}