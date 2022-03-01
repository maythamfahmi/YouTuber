using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using YouTuber.Models;

namespace YouTuber.Helpers
{
    public class YouTuberHelpers
    {
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

        public static Uri UnifyYouTubeUrl(string input)
        {
            string? id = null;

            if (input.StartsWith(Config.BaseUrl))
                id = input.Substring(input.IndexOf("v=", StringComparison.Ordinal) + 2, 11);

            if (input.StartsWith(Config.BaseUrlShare))
                id = input.Substring(input.IndexOf("be/", StringComparison.Ordinal) + 3, 11);

            if (input.Length == 11)
                id = input;

            return new Uri($"{Config.BaseUrl}{id}");
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
