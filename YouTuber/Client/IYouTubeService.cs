namespace YouTuber.Client
{
    public interface IYouTubeService
    {
        IEnumerable<string> FileToList(string file);
        void YoutubeToMp3(IEnumerable<string> urls);
        string YoutubeToMp3(string url);
    }
}