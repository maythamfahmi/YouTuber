using NUnit.Framework;
using Shouldly;
using YouTuber.Client;

namespace YouTuber.Test
{
    public class YouTuberIntegrationTest
    {
        private static readonly string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string FromFile =
            Path.GetFullPath(Path.Combine(RunningPath, @"Resources\YoutubeList.txt"));
        private static readonly IYouTubeService Service = new YouTubeService();

        [Test]
        public async Task TryToDownloadTwoVideoFromYoutube()
        {
            var path = Path.Combine(RunningPath, "download");
            string[] youtubeList = new [] { "Kv3RfdHZ25c", "3rJfBFamlIw" };
            await Service.YoutubeToMp4(youtubeList);
            var files = Directory.GetFiles(path);
            files.Length.ShouldBe(2);
            Directory.Delete(path, true);
        }

    }
}
