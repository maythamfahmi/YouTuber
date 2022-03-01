using Shouldly;
using NSubstitute;
using NUnit.Framework;
using YouTuber.Models;
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
                .When(e => e.DownloadYouTubeAsync(Arg.Any<List<string>>(), Arg.Any<MediaType.MediaCodec>()))
                .Do(_ => counter++);

            service.DownloadYouTubeAsync(dummyUrls, MediaType.MediaCodec.mp3);
            service.DownloadYouTubeAsync(dummyUrls, MediaType.MediaCodec.mp3);
            service.DownloadYouTubeAsync(dummyUrls, MediaType.MediaCodec.mp3);
            counter.ShouldBe(3);
        }

        [Test]
        public void YoutubeToMp4Exception()
        {
            IYouTubeService service = Substitute.For<IYouTubeService>();
            service
                .When(x => x.DownloadYouTubeAsync("", MediaType.MediaCodec.none))
                .Do(x => throw new Exception());

            Action action = () => service.DownloadYouTubeAsync("", MediaType.MediaCodec.none);
            action.ShouldThrow<Exception>();
        }

        [Test]
        public void PreventDuplicationTest()
        {
            IYouTubeService service = Substitute.For<IYouTubeService>();
            service
                .When(x => x.DownloadYouTubeAsync("", MediaType.MediaCodec.none))
                .Do(x => throw new Exception());

            Action action = () => service.DownloadYouTubeAsync("", MediaType.MediaCodec.none);
            action.ShouldThrow<Exception>();
        }

    }
}