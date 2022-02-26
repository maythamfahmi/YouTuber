using System.Collections.Generic;
using System.Threading.Tasks;

namespace YouTuber.Service
{
    public interface IYouTubeService
    {
        IEnumerable<string> FileToList(string file);
        Task YoutubeToMp4(IEnumerable<string> urls, string audioCodec);
        Task<string?> YoutubeToMp4(string url, string audioCodec);
    }
}