using NUnit.Framework;
using Shouldly;
using YouTuber.Models;
using YouTuber.Service;

namespace YouTuber.Test
{
    public class YouTuberIntegrationTest
    {
        private static readonly string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly IYouTubeService Service = new YouTubeService();

        [Ignore("Test only while development")]
        public async Task TryToDownloadVideoFromYoutube()
        {
            var path = Path.Combine(RunningPath, "download");
            string[] youtubeList = { "Kv3RfdHZ25c" };
            await Service.DownloadYouTubeAsync(youtubeList, MediaType.MediaCodec.none);
            var files = Directory.GetFiles(path);
            files.Length.ShouldBe(1);
            Directory.Delete(path, true);
        }

        [Ignore("Test only while development")]
        public async Task TryToDownloadVideoFromYoutubePlayground()
        {
            string[] youtubeList = new[]
                { "https://www.youtube.com/watch?v=Kv3RfdHZ25c",
                    "https://youtu.be/3rJfBFamlIw",
                    "3rJfBFamlIw"
                };
            await Service.DownloadYouTubeAsync(youtubeList, MediaType.MediaCodec.none);
        }

    }

}
