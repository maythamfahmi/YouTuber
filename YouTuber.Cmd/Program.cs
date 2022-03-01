using System.Diagnostics;
using CommandLine;
using YouTuber.Cmd.Models;
using YouTuber.Helpers;
using YouTuber.Models;
using YouTuber.Service;
using Parser = CommandLine.Parser;

namespace YouTuber.Cmd
{
    public class Program
    {
        private readonly YouTubeService _service;

        public Program()
        {
            _service = new YouTubeService();
        }

        public static async Task Main(string[] args)
        {
            await new Program().Start(args);
        }
        
        [Conditional("DEBUG")]
        private static void IsDebugCheck(ref bool debugMode)
        {
            debugMode = true;
        }

        private static int _count;

        private static string[] DebuggingTest(int test)
        {
            return test switch
            {
                //working
                1 => new[] { "--help" },
                2 => new[] { "--version" },
                3 => new[] { "-l dummy" },
                4 => new[] { "-l dummy", "-a mp3" },
                5 => new[] { "-l 3rJfBFamlIw" },
                6 => new[] { "-l https://www.youtube.com/watch?v=Kv3RfdHZ25c" },
                7 => new[] { "-l https://youtu.be/Kv3RfdHZ25c" },
                8 => new[] { "-l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw" },
                9 => new[] { "-l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw", "-a mp3" },
                10 => new[] { "-l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw", "-a m4a" },
                11 => new[] { "-a m4a", "-l Kv3RfdHZ25c" },
                12 => new[] { "-l download.txt", "-a mp3" },
                //not working
                20 => new[] { "-h" },
                21 => new[] { "-v" },
                22 => new[] { "-l dummy", "-a" },
                23 => new[] { "-l Kv3RfdHZ25c,dVsZm7_sqfw;3rJfBFamlIw" },
                24 => new[] { "-l", "-a mp3" },
                25 => new[] { "-l https://www.youtube.com/Kv3RfdHZ25c" },
                //default
                _ => new[] { "" }
            };
        }

        public async Task Start(string[] args)
        {
            bool isDebug = false;
            IsDebugCheck(ref isDebug);
            if (isDebug)
            {
                args = DebuggingTest(0);
            }

            await Parser.Default.ParseArguments<Options>(args)
                 .WithParsedAsync<Options>(async o =>
                 {
                     MediaType.MediaCodec audioCodec = YouTuberHelpers.MapAudioType(o.Audio);

                     if (o.List != null)
                     {
                         var downloadList = GetDownloadList(o.List);
                         var timer = new Timer(TimerCallback!, null, 0, 100);
                         await TryDownloadYouTubeAsync(downloadList, audioCodec);
                     }
                 });
        }

        private static void TimerCallback(object o)
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
                list = YouTuberHelpers.FileToList(param).ToArray();
            }
            else if (param == "dummy")
            {
                YouTuberHelpers.CreateSampleList();
                list = Config.SampleVideoList;
            }

            return list;
        }

        private async Task TryDownloadYouTubeAsync(IEnumerable<string> youtubeList, MediaType.MediaCodec audioCodec)
        {
            try
            {
                await _service.DownloadYouTubeAsync(youtubeList, audioCodec);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        
    }
}
