using System.Diagnostics;
using YouTuber.Client;

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

        public static async Task Main(string[] args)
        {
            bool isDebug = false;
            IsDebugCheck(ref isDebug);
            if (isDebug)
            {
                args = new[] { "-l", "3rJfBFamlIw" };
                //args = new[] { "-l", "3rJfBFamlIw", "dVsZm7_sqfw", "Kv3RfdHZ25c" };
                //args = new[] { "-d" };
            }

            var input = args.Length == 0 ? "" : args[0];
            if (string.IsNullOrEmpty(input))
            {
                Help();
            }
            else if (input is "-d" or "--dummy")
            {
                CreateSampleList();
                await Service.YoutubeToMp4(ShortVideos);
            }
            else if (input.EndsWith(".txt"))
            {
                var enumerable = Service.FileToList(input);
                var urls = enumerable as IList<string> ?? enumerable.ToList();
                if (!urls.Any())
                {
                    Console.WriteLine("Your list is empty");
                }
                else
                {
                    await Service.YoutubeToMp4(urls);
                }
            }
            else if (input is "-l" or "--list")
            {
                if (string.IsNullOrWhiteSpace(args[1]))
                {
                    Help();
                }
                else
                {
                    try
                    {
                        await Service.YoutubeToMp4(GetList(args[1]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Help("download");
                    }
                }
            }
            else if (input is "-h" or "--help" || input.Any())
            {
                Help();
            }
        }

        public static void CreateSampleList()
        {
            File.WriteAllLines("download.txt", ShortVideos);
        }

        public static IEnumerable<string> GetList(string input)
        {
            return input.Split(';').ToList();
        }

        public static void Help(string help = "all")
        {
            switch (help)
            {
                case "all":
                    Console.WriteLine("[-h | --help]        Get help");
                    Console.WriteLine("[-d | --dummy]       Download sample files");
                    Console.WriteLine(
                        "[-l | --list]        Download directly, use ';' as seperator for multiple urls/Ids");
                    Console.WriteLine("example: -l https://www.youtube.com/watch?v=Kv3RfdHZ25c");
                    Console.WriteLine("example: -l Kv3RfdHZ25c;dVsZm7_sqfw;3rJfBFamlIw");
                    Console.WriteLine("[download.txt]       Create your own list\n");
                    Console.WriteLine("Note: Please read README.md.");
                    Console.WriteLine(
                        "By using this App, you agree to be bound by the terms and conditions of this Agreement");
                    break;
                case "download":
                    Console.WriteLine("example: -l https://www.youtube.com/watch?v=Kv3RfdHZ25c");
                    Console.WriteLine(
                        "example: -l https://www.youtube.com/watch?v=Kv3RfdHZ25c;https://www.youtube.com/watch?v=dVsZm7_sqfw;https://www.youtube.com/watch?v=3rJfBFamlIw");
                    break;
            }
        }
    }
}