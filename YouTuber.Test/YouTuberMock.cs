using System;
using Shouldly;
using NSubstitute;
using NUnit.Framework;
using YouTuber.Client;
using System.Collections.Generic;

namespace YouTuber.Test
{
    public class YouTuberMock
    {
        [Test]
        public void YoutubeToMp3Calls()
        {
            var youTubeClient = Substitute.For<IYouTubeService>();
            List<string> dummyUrls = new List<string>() {"", ""};

            var counter = 0;
            youTubeClient.When(e => e.YoutubeToMp3(Arg.Any<List<string>>()))
                .Do(e => counter++);

            youTubeClient.YoutubeToMp3(dummyUrls);
            youTubeClient.YoutubeToMp3(dummyUrls);
            youTubeClient.YoutubeToMp3(dummyUrls);
            counter.ShouldBe(3);
        }

        [Test]
        public void YoutubeToMp3Exception()
        {
            var youTubeClient = Substitute.For<IYouTubeService>();
            youTubeClient
                .When(x => x.YoutubeToMp3(""))
                .Do(x => throw new Exception());

            Action action1 = () => youTubeClient.YoutubeToMp3("");
            action1.ShouldThrow<Exception>();
        }

        [Test]
        public void FileToListMock()
        {
            var youTubeClient = Substitute.For<IYouTubeService>();
            youTubeClient.FileToList(Arg.Any<string>()).Returns(new List<string> {"1", "2"});

            youTubeClient.FileToList("").ShouldContain(e => e.Contains("1"));
            youTubeClient.FileToList("").ShouldContain(e => e.Contains("2"));
        }

        [Test]
        public void FileToListFileMock()
        {
            var reader = Substitute.For<YouTubeService>();
            reader.When(x => x.FileToList("youtubelist.txt")).DoNotCallBase();
            reader.FileToList("youtubelist.txt")
                .Returns(new List<string>() {"1", "2", "3"}
                );

            reader.YoutubeToMp3(reader.FileToList("youtubelist.txt"));
        }
    }
}