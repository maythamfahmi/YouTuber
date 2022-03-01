using Shouldly;
using NUnit.Framework;
using YouTuber.Helpers;
using YouTuber.Service;

namespace YouTuber.Test
{
    public class YouTuberTest
    {
        [Test]
        public void FileToListTest()
        {
            IList<string> youtubeList = Config.SampleVideoList;

            youtubeList.Count.ShouldBe(3);
            youtubeList.ShouldContain("https://www.youtube.com/watch?v=Kv3RfdHZ25c");
            youtubeList.ShouldAllBe(e => e.StartsWith("https://www.youtube.com/watch?v="));
        }

        //[Test]
        //public void ResourceFileTest()
        //{
        //    string[] stringSeparators = { "\r\n" };
        //    var fileContent = File.ReadAllText(FromFile);
        //    var lines = fileContent
        //        .Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
        //    IList<string> youtubeList = Service.FileToList(FromFile).ToList();

        //    lines.ForEach(e => { youtubeList.ShouldContain(e); });
        //}

        //[Test]
        //public void FileToListMock()
        //{
        //    var service = Substitute.For<IYouTubeService>();
        //    service
        //        .FileToList(Arg.Any<string>())
        //        .Returns(new List<string> { "1", "2" });

        //    service
        //        .FileToList("")
        //        .ShouldContain(e => e.Contains('1'));
        //    service
        //        .FileToList("")
        //        .ShouldContain(e => e.Contains('2'));
        //}

        //[Test]
        //public void FileToListFileMock()
        //{
        //    var service = Substitute.For<YouTubeService>();
        //    service
        //        .When(e => e.FileToList("youtubelist.txt"))
        //        .DoNotCallBase();

        //    service
        //        .FileToList("youtubelist.txt")
        //        .Returns(new List<string>() { "1", "2", "3" });

        //    _ = service.YoutubeToMp4(service.FileToList("youtubelist.txt"));
        //}
    }
}