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

        [Test]
        public async Task TryToDownloadTwoVideoFromYoutube()
        {
            var path = Path.Combine(RunningPath, "download");
            string[] youtubeList = { "Kv3RfdHZ25c", "3rJfBFamlIw" };
            await Service.DownloadYouTubeAsync(youtubeList, MediaType.MediaCodec.none);
            var files = Directory.GetFiles(path);
            files.Length.ShouldBe(2);
            Directory.Delete(path, true);
        }

        [Ignore("Playground")]
        public async Task TryToDownloadVideoFromYoutube()
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
