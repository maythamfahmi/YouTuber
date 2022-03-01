using Shouldly;
using NUnit.Framework;
using YouTuber.Helpers;
using YouTuber.Models;
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

        [TestCase(1, "https://www.youtube.com/watch?v=3rJfBFamlIw", "https://www.youtube.com/watch?v=3rJfBFamlIw")]
        [TestCase(2, "https://youtu.be/3rJfBFamlIw", "https://www.youtube.com/watch?v=3rJfBFamlIw")]
        [TestCase(3, "3rJfBFamlIw", "https://www.youtube.com/watch?v=3rJfBFamlIw")]
        [TestCase(4, "3rJfBFamlI", "")]
        [TestCase(5, "3rJfBFamlIws", "")]
        [TestCase(6, "", "")]
        [TestCase(7, null, "")]
        public void UnifyYouTubeUrlTest(int order, string input, string expected)
        {
            var youTubeUrl = YouTuberHelpers.UnifyYouTubeUrl(input);
            youTubeUrl.ShouldBe(expected);
        }

        [TestCase(1, null, MediaType.MediaCodec.none)]
        [TestCase(2, "", MediaType.MediaCodec.none)]
        [TestCase(3, "mp3", MediaType.MediaCodec.mp3)]
        [TestCase(4, "m4a", MediaType.MediaCodec.m4a)]
        [TestCase(5, "mp4", MediaType.MediaCodec.mp4)]
        [TestCase(6, "mp", MediaType.MediaCodec.none)]
        public void MapAudioTypeTest(int order, string input, MediaType.MediaCodec expected)
        {
            var codec = YouTuberHelpers.MapAudioType(input);
            codec.ShouldBe(expected);
        }

        [Test]
        public void IsDuplicateTest()
        {
            var service = new YouTubeService();
            service
                .IsDuplicate(YouTuberHelpers.UnifyYouTubeUrl("https://www.youtube.com/watch?v=3rJfBFamlIw"))
                .ShouldBe(false);

            service
                .IsDuplicate(YouTuberHelpers.UnifyYouTubeUrl("https://www.youtube.com/watch?v=3rJfBFamlIw"))
                .ShouldBe(true);

            service
                .IsDuplicate(YouTuberHelpers.UnifyYouTubeUrl("https://www.youtube.com/watch?v=3rJfBFamlIw"))
                .ShouldBe(true);
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