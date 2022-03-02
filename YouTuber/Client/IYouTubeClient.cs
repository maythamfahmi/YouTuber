using System.Collections.Generic;
using System.Threading.Tasks;
using VideoLibrary;

namespace YouTuber.Client
{
    public interface IYouTubeClient
    {
        Task<YouTubeVideo> DownloadYouTubeAsync(string input);
        Task<IEnumerable<YouTubeVideo>> GetAllAvailableFormatAsync(string input);
    }
}