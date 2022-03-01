using System;
using System.Collections.Generic;
using System.IO;
using YouTuber.Models;

namespace YouTuber.Helpers
{
    public class YouTuberHelpers
    {
        private const string BaseUrl = "https://www.youtube.com/watch?v=";
        private const string BaseUrlShare = "https://youtu.be/";

        public static IEnumerable<string> FileToList(string file)
        {
            using FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            using StreamReader sr = new StreamReader(fs);
            string[] results = sr.ReadToEnd()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return results;
        }

        public static void CreateFolder(string folder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public static Uri Url(string url)
        {
            if (url.StartsWith(BaseUrl))
            {

            }

            if (url.StartsWith(BaseUrlShare))
            {

            }

            string str = url.Length == 11 ? $"{BaseUrl}{url}" : url;
            Uri uri = new Uri(str);
            return uri;
        }

        public static MediaType.MediaCodec MapAudioType(string? audioCodec)
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

        public static void CreateSampleList()
        {
            File.WriteAllLines(Config.DownloadFile, Config.SampleVideoList);
        }
    }
}
