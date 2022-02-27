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
            await Service.YoutubeToMp4(youtubeList, MediaType.MediaCodec.mp3);
            var files = Directory.GetFiles(path);
            files.Length.ShouldBe(2);
            Directory.Delete(path, true);
        }

        [Test]
        public async Task TryToDownloadSingleVideoFromYoutube()
        {
            string youtubeList = "Kv3RfdHZ25c";
            await Service.YoutubeToMp4(youtubeList, MediaType.MediaCodec.none);
        }

        [Test]
        public async Task TryToDownloadTwoVideoFromYoutube2()
        {
            string[] youtubeList = new[] { "Kv3RfdHZ25c", "3rJfBFamlIw" };
            await Service.YoutubeToMp4(youtubeList, MediaType.MediaCodec.mp3);
        }

    }

}
