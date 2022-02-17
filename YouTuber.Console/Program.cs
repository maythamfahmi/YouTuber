using YouTuber.Client;

namespace YouTuber.Cmd
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
            if (input == "-d" || input == "--dummy" || string.IsNullOrEmpty(input))
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
                    Console.WriteLine("Your list is empty");
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
                }
                else
                {
                    try
                    {
                        Service.YoutubeToMp3(GetList(args[1]));
                    }
                    catch
                    {
                        Help("download");
                    }
                }
            }
            else if (input == "-h" || input == "--help" || input.Any())
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
            if (help == "all")
            {
                Console.WriteLine("[-h | --help]        Get help");
                Console.WriteLine("[-d | --dummy]       Download sample files");
                Console.WriteLine(
                    "[-l | --list]        Download directly, use ';' as seperator for multiple urls/Ids");
                Console.WriteLine("example: -l https://www.youtube.com/watch?v=y9ajRIgTJNA");
                Console.WriteLine("example: -l y9ajRIgTJNA;pYlYt9iuJdc;NcumhqTDPpE");
                Console.WriteLine("[download.txt]       Create your own list\n");
                Console.WriteLine("Note: Please read README.md.");
                Console.WriteLine(
                    "By using this App, you agree to be bound by the terms and conditions of this Agreement");
            }
            else if (help == "download")
            {
                Console.WriteLine("example: -l https://www.youtube.com/watch?v=y9ajRIgTJNA");
                Console.WriteLine(
                    "example: -l https://www.youtube.com/watch?v=y9ajRIgTJNA;https://www.youtube.com/watch?v=pYlYt9iuJdc;https://www.youtube.com/watch?v=NcumhqTDPpE");
            }
        }
    }
}