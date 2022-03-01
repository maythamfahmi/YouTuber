namespace YouTuber
{
    public static class Config
    {
        public const string BaseUrl = "https://www.youtube.com/watch?v=";
        public const string BaseUrlShare = "https://youtu.be/";
        public const string DownloadFile = "download.txt";
        public const string BaseFolder = "download";
        public const string InvalidYouTube = "Invalid YouTube Url/Id";
        public const string DuplicateYouTube = "Duplicate YouTube Url/Id";

        public static readonly string[] SampleVideoList =
        {
            "https://www.youtube.com/watch?v=Kv3RfdHZ25c",
            "https://www.youtube.com/watch?v=dVsZm7_sqfw",
            "https://www.youtube.com/watch?v=3rJfBFamlIw"
        };

    }

}
