using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using VideoLibrary;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;
using YouTuber.Models;

namespace YouTuber.Service
{
    public class YouTubeService : IYouTubeService
    {
        private const string BaseUrl = "https://www.youtube.com/watch?v=";
        private const string BaseFolder = "download";
        private readonly HashSet<string> _set = new HashSet<string>();

        public virtual async Task YoutubeToMp4(IEnumerable<string> urls, MediaType.MediaCodec audioCodec = MediaType.MediaCodec.none)
        {
            ParallelOptions options = new ParallelOptions();
            int maxProc = Environment.ProcessorCount;
            options.MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling(maxProc * 1.75));

            int count = 1;

            await Parallel.ForEachAsync(urls, options, async (url, token) =>
            {
                var result = await YoutubeToMp4(url, audioCodec);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine($"{count++}- {result}");
                }
            });
        }

        public virtual async Task<string?> YoutubeToMp4(string url, MediaType.MediaCodec audioCodec)
        {
            string uri = Url(url.Trim()).ToString();

            if (uri.Replace(BaseUrl, "").Length != 11)
            {
                return "Looks like this is invalid url/id";
            }

            lock (_set)
            {
                if (_set.Contains(url))
                {
                    return null;
                }

                _set.Add(url);
            }

            YouTube youtube = YouTube.Default;
            YouTubeVideo video = await youtube.GetVideoAsync(uri);
            string validationMessage = ValidateVideo(video);
            if (validationMessage != "OK") return validationMessage;

            CreateFolder(BaseFolder);
            string path = Path.Combine(BaseFolder, video.FullName);
            await File.WriteAllBytesAsync(path, await video.GetBytesAsync());
            if (audioCodec != MediaType.MediaCodec.none)
            {
                lock (_set)
                {
                    //todo: investigation of possible solution required
                    //parallel is not possible hence ffmpeg.exe process need to done first.
                    ExtractAudio(path, audioCodec).Wait();
                    File.Delete(path);
                }
            }
            return $"{CleanFilename(video.FullName)} video is ready under {BaseFolder}";
        }

        private static async Task ExtractAudio(string path, MediaType.MediaCodec codec)
        {
            var currentFolder = Directory.GetCurrentDirectory();
            var ffmpegPath = $"{currentFolder}/FFmpeg";
            FFmpeg.SetExecutablesPath(ffmpegPath, "FFmpeg");
            await FFmpegDownloader.GetLatestVersion(FFmpegVersion.Official, ffmpegPath);
            FileInfo fi = new FileInfo(path);
            string inputPath = fi.FullName;
            string outputPath = Path.ChangeExtension(inputPath, codec.ToString());

            if (File.Exists(outputPath))
            {
                File.Delete(outputPath);
            }

            var conversion = await FFmpeg.Conversions.FromSnippet.ExtractAudio(inputPath, outputPath);
            await conversion.Start();
            await Task.Delay(500);
        }

        private static string ValidateVideo(YouTubeVideo? video)
        {
            if (video == null)
            {
                return "video is null";
            }

            try
            {
                var getUri = video.Uri;
            }
            catch (AggregateException)
            {
                return "Looks like this is invalid url/id";
            }
            catch (InvalidOperationException)
            {
                var title = CleanFilename(video.FullName);
                return $"{title} is properly copyright protected or locked!";
            }
            catch (Exception e)
            {
                return $"Unknown error\nPlease report a bug with following info:!\n{e.Message}";
            }

            return "OK";
        }

        public virtual IEnumerable<string> FileToList(string file)
        {
            using FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            using StreamReader sr = new StreamReader(fs);
            string[] results = sr.ReadToEnd()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return results;
        }

        private static void CreateFolder(string folder)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), folder);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static string CleanFilename(string rawFilename)
        {
            return rawFilename
                .Replace(" - YouTube", "")
                .Replace(".webm", "")
                .Replace(".mp3", "")
                .Replace(".mp4", "");
        }

        private static Uri Url(string url)
        {
            string str = url.Length == 11 ? $"{BaseUrl}{url}" : url;
            Uri uri = new Uri(str);
            return uri;
        }

    }

}
