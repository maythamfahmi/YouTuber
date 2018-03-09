using System.IO;
using System.Linq;
using YouTuber.Client;
using System.Collections.Generic;

namespace YouTuber.Console
{
    public class Program
    {
        private static readonly YouTubeService Service = new YouTubeService();

        //Sample download
        private static readonly string[] ShortVideos =
        {
            "https://www.youtube.com/watch?v=y9ajRIgTJNA",
            "https://www.youtube.com/watch?v=pYlYt9iuJdc",
            "https://www.youtube.com/watch?v=NcumhqTDPpE"
        };

        public static void Main(string[] args)
        {
            var input = args.Length == 0 ? "" : args[0];
            if (input == "-d" || input == "--dummy")
            {
                CreateSampleList();
                Service.YoutubeToMp3(ShortVideos);
            }
            else if (input.EndsWith(".txt"))
            {
                var enumerable = Service.FileToList(input);
                var urls = enumerable as IList<string> ?? enumerable.ToList();
                if (!urls.Any())
                {
                    System.Console.WriteLine("Your list is empty");
                }
                else
                {
                    Service.YoutubeToMp3(urls);
                }
            }
            else if (input == "-l" || input == "--list")
            {
                if (string.IsNullOrWhiteSpace(args[1]))
                {
                    System.Console.WriteLine("example: -l https://www.youtube.com/watch?v=y9ajRIgTJNA");
                    System.Console.WriteLine(
                        "example: -l https://www.youtube.com/watch?v=y9ajRIgTJNA;https://www.youtube.com/watch?v=pYlYt9iuJdc;https://www.youtube.com/watch?v=NcumhqTDPpE");
                }
                else
                {
                    Service.YoutubeToMp3(GetList(args[1]));
                }
            }
            else if (input == "-h" || input == "--help" || input.Any())
            {
                System.Console.WriteLine("[-h | --help]        Get help");
                System.Console.WriteLine("[-d | --dummy]       Download sample files");
                System.Console.WriteLine("[-l | --list]        Download directly, use ';' as seperator for multiple urls/Ids");
                System.Console.WriteLine("example: -l https://www.youtube.com/watch?v=y9ajRIgTJNA");
                System.Console.WriteLine("example: -l y9ajRIgTJNA;pYlYt9iuJdc;NcumhqTDPpE");
                System.Console.WriteLine("[download.txt]       Create your own list\n");
                System.Console.WriteLine("Note: Please read README.md.");
                System.Console.WriteLine("By using this App, you agree to be bound by the terms and conditions of this Agreement");
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
    }
}