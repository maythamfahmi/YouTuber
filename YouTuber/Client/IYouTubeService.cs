using System.Collections.Generic;
using System.Threading.Tasks;

namespace YouTuber.Client
{
    public interface IYouTubeService
    {
        IEnumerable<string> FileToList(string file);
        Task YoutubeToMp4(IEnumerable<string> urls, bool onlyAudio, string codec);
        Task<string?> YoutubeToMp4(string url, bool onlyAudio, string codec);
    }
}