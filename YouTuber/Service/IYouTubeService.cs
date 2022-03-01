using System.Collections.Generic;
using System.Threading.Tasks;
using YouTuber.Models;

namespace YouTuber.Service
{
    public interface IYouTubeService
    {
        Task DownloadYouTubeAsync(IEnumerable<string> urls, MediaType.MediaCodec audioCodec);
        Task<string?> DownloadYouTubeAsync(string url, MediaType.MediaCodec codec);
    }
}