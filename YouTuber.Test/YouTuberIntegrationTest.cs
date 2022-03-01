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
            string[] youtubeList = new[] { "Kv3RfdHZ25c", "3rJfBFamlIw" };
            await Service.DownloadYouTubeAsync(youtubeList, MediaType.MediaCodec.none);
            var files = Directory.GetFiles(path);
            files.Length.ShouldBe(2);
            Directory.Delete(path, true);
        }

        [Test]
        public async Task TryToDownloadTwoVideoFromYoutube1()
        {
            var path = Path.Combine(RunningPath, "download");
            string[] youtubeList = new[] { "https://www.youtube.com/watch?v=Kv3RfdHZ25c", "3rJfBFamlIw", "https://youtu.be/3rJfBFamlIw" };
            await Service.DownloadYouTubeAsync(youtubeList, MediaType.MediaCodec.none);
            var files = Directory.GetFiles(path);
            files.Length.ShouldBe(2);
            Directory.Delete(path, true);
        }

    }

}
