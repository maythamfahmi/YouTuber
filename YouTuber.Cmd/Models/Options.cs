using CommandLine;

namespace YouTuber.Cmd.Models
{
    public class Options
    {
        [Option('l', "list", Required = false, Separator = ';',
            HelpText = "Download single or multiple youtube by url or id, use ; as separator.\n" +
                       "DownloadYouTube -l xxxxxxxxxxx;xxxxxxxxxxx;xxxxxxxxxxx\n" +
                       "DownloadYouTube -l xxxxxxxxxxx")]
        public IEnumerable<string>? List { get; set; }

        [Option('d', "dummy", Required = false,
            HelpText = "Download 3 preselected videos using download.txt file, for demo purpose.")]
        public bool? Dummy { get; set; }

        [Option('a', "audio", Required = false,
            HelpText = "Extract only audio. -a mp3 or -a m4a.")]
        public string? Audio { get; set; }
    }
}
