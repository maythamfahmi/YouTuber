using System;
using Shouldly;
using System.IO;
using System.Linq;
using YouTuber.Client;
using NUnit.Framework;
using System.Collections.Generic;

namespace YouTuber.Test
{
    public class YouTubeTest
    {
        private static readonly string FileContent = Properties.Resources.YoutubeList;
        private static readonly string RunningPath = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string FromFile =
            Path.GetFullPath(Path.Combine(RunningPath, @"..\..\Resources\YoutubeList.txt"));

        private static readonly YouTubeService YouTubeService = new YouTubeService();
        private const string ProtectedContent = "https://www.youtube.com/watch?v=oRdxUFDoQe0";

        [Test]
        public void ProtectedContentTest()
        {
            YouTubeService.YoutubeToMp3(ProtectedContent).ShouldContain("properly copyright protected");
        }

        [Test]
        public void FileToListTest()
        {
            IList<string> youtubeList = YouTubeService.FileToList(FromFile).ToList();

            youtubeList.Count().ShouldBe(3);
            youtubeList.ShouldContain("https://www.youtube.com/watch?v=pYlYt9iuJdc");
            youtubeList.ShouldAllBe(e => e.StartsWith("https://www.youtube.com/watch?v="));
        }

        [Test]
        public void ResourceFileTest()
        {
            string[] stringSeparators = {"\r\n"};
            var lines = FileContent.Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries).ToList();
            IList<string> youtubeList = YouTubeService.FileToList(FromFile).ToList();

            lines.ForEach(e => { youtubeList.ShouldContain(e); });
        }
    }
}