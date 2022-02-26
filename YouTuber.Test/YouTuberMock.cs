using Shouldly;
using NSubstitute;
using NUnit.Framework;
using YouTuber.Service;

namespace YouTuber.Test
{
    public class YouTuberMock
    {
        [Test]
        public void YoutubeToMp4Calls()
        {
            IYouTubeService service = Substitute.For<IYouTubeService>();
            List<string> dummyUrls = new List<string>() { "", "" };

            int counter = 0;
            service
                .When(e => e.YoutubeToMp4(Arg.Any<List<string>>(), Arg.Any<string>()))
                .Do(_ => counter++);

            service.YoutubeToMp4(dummyUrls, "mp3");
            service.YoutubeToMp4(dummyUrls, "mp3");
            service.YoutubeToMp4(dummyUrls, "mp3");
            counter.ShouldBe(3);
        }

        [Test]
        public void YoutubeToMp4Exception()
        {
            IYouTubeService service = Substitute.For<IYouTubeService>();
            service
                .When(x => x.YoutubeToMp4("", ""))
                .Do(x => throw new Exception());

            Action action = () => service.YoutubeToMp4("", "");
            action.ShouldThrow<Exception>();
        }

        [Test]
        public void FileToListMock()
        {
            var service = Substitute.For<IYouTubeService>();
            service
                .FileToList(Arg.Any<string>())
                .Returns(new List<string> { "1", "2" });

            service
                .FileToList("")
                .ShouldContain(e => e.Contains('1'));
            service
                .FileToList("")
                .ShouldContain(e => e.Contains('2'));
        }

        [Test]
        public void FileToListFileMock()
        {
            var service = Substitute.For<YouTubeService>();
            service
                .When(e => e.FileToList("youtubelist.txt"))
                .DoNotCallBase();

            service
                .FileToList("youtubelist.txt")
                .Returns(new List<string>() { "1", "2", "3" });

            _ = service.YoutubeToMp4(service.FileToList("youtubelist.txt"), null);
        }
    }
}