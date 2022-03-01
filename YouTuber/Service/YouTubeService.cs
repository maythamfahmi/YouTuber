using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VideoLibrary;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;
using YouTuber.Helpers;
using YouTuber.Models;

namespace YouTuber.Service
{
    public class YouTubeService : IYouTubeService
    {
        private readonly HashSet<string> _set = new HashSet<string>();

        public virtual async Task DownloadYouTubeAsync(IEnumerable<string> urls, MediaType.MediaCodec audioCodec = MediaType.MediaCodec.none)
        {
            ParallelOptions options = new ParallelOptions();
            int maxProc = Environment.ProcessorCount;
            options.MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling(maxProc * 1.75));

            int count = 1;

            await Parallel.ForEachAsync(urls, options, async (url, token) =>
            {
                var result = await DownloadYouTubeAsync(url, audioCodec);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine($"{count++}- {result}");
                }
            });
        }

        public virtual async Task<string?> DownloadYouTubeAsync(string url, MediaType.MediaCodec codec)
        {
            string uri = YouTuberHelpers.Url(url.Trim()).ToString();

            if (IsDuplicate(url))
            {
                return null;
            }
            
            YouTube youtube = YouTube.Default;
            YouTubeVideo video = await youtube.GetVideoAsync(uri);
            string validationMessage = ValidateVideo(video);
            
            if (validationMessage != "OK")
            {
                return validationMessage;
            }

            YouTuberHelpers.CreateFolder(Config.BaseFolder);
            string path = Path.Combine(Config.BaseFolder, video.FullName);
            
            await File.WriteAllBytesAsync(path, await video.GetBytesAsync());
            
            GetAudio(path, codec);
            
            return $"{video.Title} is ready under {Config.BaseFolder}";
        }

        private bool IsDuplicate(string url)
        {
            lock (_set)
            {
                if (_set.Contains(url))
                {
                    return true;
                }

                _set.Add(url);
                return false;
            }
        }

        private void GetAudio(string path, MediaType.MediaCodec codec)
        {
            if (codec == MediaType.MediaCodec.none) return;
            lock (_set)
            {
                ExtractAudio(path, codec).Wait();
                File.Delete(path);
            }
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
                return $"{video.Title} is properly copyright protected or locked!";
            }
            catch (Exception e)
            {
                return $"Unknown error\nPlease report a bug with following info:!\n{e.Message}";
            }

            return "OK";
        }

    }

}
