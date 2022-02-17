using Shouldly;
using YouTuber.Client;
using NUnit.Framework;

namespace YouTuber.Test
{
    public class YouTubeTest
    {
        private static readonly string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string FromFile =
            Path.GetFullPath(Path.Combine(RunningPath, @"Resources\YoutubeList.txt"));

        private static readonly YouTubeService YouTubeService = new YouTubeService();

        [Test]
        public void FileToListTest()
        {
            IList<string> youtubeList = YouTubeService.FileToList(FromFile).ToList();

            youtubeList.Count().ShouldBe(3);
            youtubeList.ShouldContain("https://www.youtube.com/watch?v=Kv3RfdHZ25c");
            youtubeList.ShouldAllBe(e => e.StartsWith("https://www.youtube.com/watch?v="));
        }

        [Test]
        public void ResourceFileTest()
        {
            string[] stringSeparators = { "\r\n" };
            var fileContent = File.ReadAllText(FromFile);
            var lines = fileContent.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
            IList<string> youtubeList = YouTubeService.FileToList(FromFile).ToList();

            lines.ForEach(e => { youtubeList.ShouldContain(e); });
        }
    }
}