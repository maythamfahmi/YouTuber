using System.Threading.Tasks;
using VideoLibrary;

namespace YouTuber.Client
{
    public class YouTubeClient : IYouTubeClient
    {

        public virtual async Task<YouTubeVideo> DownloadYouTubeAsync(string input)
        {
            YouTube youtube = YouTube.Default;
            return await youtube.GetVideoAsync(input);
        }

    }

}
