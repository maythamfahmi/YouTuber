using System.Diagnostics;
using CommandLine;
using YouTuber.Helpers;
using YouTuber.Models;
using YouTuber.Service;
using Parser = CommandLine.Parser;

namespace YouTuber.Cmd
{
    public class Program
    {
        private static readonly YouTubeService Service = new YouTubeService();

        [Conditional("DEBUG")]
        private static void IsDebugCheck(ref bool debugMode)
        {
            debugMode = true;
        }

        //Sample download
        private static readonly string[] ShortVideos =
        {
            "https://www.youtube.com/watch?v=Kv3RfdHZ25c",
            "https://www.youtube.com/watch?v=dVsZm7_sqfw",
            "https://www.youtube.com/watch?v=3rJfBFamlIw"
        };

        public class Options
        {
            [Option('l', "list", Required = true, Separator = ';',
                HelpText = "Download single or multiple youtube by url or id, use ; as separator.\n" +
                           "./DownloadYouTube -l xxxxxxxxxxx;xxxxxxxxxxx;xxxxxxxxxxx\n" +
                           "./DownloadYouTube -l xxxxxxxxxxx")]
            public IEnumerable<string>? List { get; set; }

            [Option('a', "audio", Required = false,
                HelpText = "Extract only audio. -a mp3 or -a m4a.")]
            public string? Audio { get; set; }
        }

        public static Timer? Timer { get; private set; }
        private static int _count;

        public static async Task Main(string[] args)
        {
            bool isDebug = false;
            IsDebugCheck(ref isDebug);
            if (isDebug)
            {
                //working
                //args = new[] { "--help" };
                //args = new[] { "--version" };
                args = new[] { "-l dummy" };
                //args = new[] { "-l dummy", "-a mp3" };
                //args = new[] { "-l 3rJfBFamlIw" };
                //args = new[] { "-l https://www.youtube.com/watch?v=Kv3RfdHZ25c" };
                //args = new[] { "-l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw" };
                //args = new[] { "-l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw", "-a mp3" };
                //args = new[] { "-l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw", "-a m4a" };
                //args = new[] { "-a m4a", "-l Kv3RfdHZ25c" };
                //args = new[] { "-l download.txt", "-a mp3" };

                //not working
                //args = new[] { "-h" };
                //args = new[] { "-v" };
                //args = new[] { "-l dummy", "-a" };
                //args = new[] { "-l Kv3RfdHZ25c,dVsZm7_sqfw;3rJfBFamlIw" };
                //args = new[] { "-l", "-a mp3" };
            }

            await Parser.Default.ParseArguments<Options>(args)
                 .WithParsedAsync<Options>(async o =>
                 {
                     MediaType.MediaCodec audioCodec = GetAudioType(o.Audio);

                     if (o.List != null)
                     {
                         var downloadList = GetDownloadList(o.List);
                         Timer = new Timer(TimerCallback!, null, 0, 100);
                         await DownloadYouTube(downloadList, audioCodec);
                     }
                 });
        }

        private static void TimerCallback(Object o)
        {
            _count++;
            ConsoleUtility.WriteProgress(_count, true);
        }

        private static IEnumerable<string> GetDownloadList(IEnumerable<string> youtubeList)
        {
            string[] list = youtubeList as string[] ?? youtubeList.ToArray();
            string param = list[0].Trim();

            if (param.EndsWith(".txt"))
            {
                list = Service.FileToList(param).ToArray();
            }
            else if (param == "dummy")
            {
                CreateSampleList();
                list = ShortVideos;
            }

            return list;
        }

        private static async Task DownloadYouTube(IEnumerable<string> youtubeList, MediaType.MediaCodec audioCodec)
        {
            try
            {
                await Service.YoutubeToMp4(youtubeList, audioCodec);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static MediaType.MediaCodec GetAudioType(string? audioCodec)
        {
            if (string.IsNullOrEmpty(audioCodec)) return MediaType.MediaCodec.none;
            var audio = audioCodec.Trim();
            return audio switch
            {
                "mp3" => MediaType.MediaCodec.mp3,
                "m4a" => MediaType.MediaCodec.m4a,
                _ => MediaType.MediaCodec.none
            };
        }

        private static void CreateSampleList()
        {
            File.WriteAllLines("download.txt", ShortVideos);
        }

    }
}
