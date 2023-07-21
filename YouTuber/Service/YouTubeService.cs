using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using VideoLibrary;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Downloader;
using YouTuber.Client;
using YouTuber.Helpers;
using YouTuber.Models;
using static System.Net.Mime.MediaTypeNames;

namespace YouTuber.Service
{
    public class YouTubeService : IYouTubeService
    {
        private readonly HashSet<string> _set = new HashSet<string>();
        private readonly IYouTubeClient _client;

        public YouTubeService()
        {
            _client = new YouTubeClient();
        }

        public virtual async Task DownloadYouTubeAsync(IEnumerable<string> urls,
            MediaType.MediaCodec codec = MediaType.MediaCodec.none)
        {
            ParallelOptions options = new ParallelOptions();
            int maxProc = Environment.ProcessorCount;
            options.MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling(maxProc * 1.75));

            int count = 1;

            await Parallel.ForEachAsync(urls, options, async (url, token) =>
            {
                var result = await DownloadYouTubeAsync(url, codec);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine($"{count++}- {result}");
                }
            });
        }

        public virtual async Task<string?> DownloadYouTubeAsync(string url, MediaType.MediaCodec codec)
        {
            string unified = YouTuberHelpers.UnifyYouTubeUrl(url);

            if (string.IsNullOrWhiteSpace(unified))
            {
                return Config.InvalidYouTube;
            }

            if (IsDuplicate(unified))
            {
                return Config.DuplicateYouTube;
            }

            IEnumerable<YouTubeVideo> videos = await _client.GetAllAvailableFormatAsync(unified);

            var video = FilterOnlyVideoFormats(videos);

            string validationMessage = ValidateVideo(video);

            if (validationMessage != "OK")
            {
                return validationMessage;
            }

            YouTuberHelpers.CreateFolder(Config.BaseFolder);

            var fileName = string.Empty;

            if (video!.FileExtension == "")
            {
                if (video.AdaptiveKind == AdaptiveKind.Audio)
                {
                    fileName = $"{video!.FullName}.mp3";
                }
                if (video.AdaptiveKind == AdaptiveKind.Video)
                {
                    fileName = $"{video!.FullName}.mp4";
                }
            }
            else
            {
                fileName = $"{video!.FullName}";
            }

            string path = Path.Combine(Config.BaseFolder, fileName);
            
            await File.WriteAllBytesAsync(path, await video.GetBytesAsync());

            GetAudio(path, codec);

            return $"{video.Title} is ready under {Config.BaseFolder}";
        }

        public virtual bool IsDuplicate(string url)
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

        private static IEnumerable<YouTubeVideo> FilterOnlyValidFormats(IEnumerable<YouTubeVideo> videos)
        {
            return videos
                .Where(e => e.ContentLength != null)
                .Where(e => e.ContentLength != 0)
                .Where(e => e.AudioBitrate != -1);
        }

        private static YouTubeVideo? FilterOnlyVideoFormats(IEnumerable<YouTubeVideo> videos)
        {
            YouTubeVideo? youTubeVideo = null;

            IEnumerable<YouTubeVideo> list = FilterOnlyValidFormats(videos)
                .Where(e => !string.IsNullOrEmpty(e.FileExtension));

            if (list == null || !list.Any())
            {
                list = FilterOnlyValidFormats(videos);

                if (list.All(e => e.AdaptiveKind == AdaptiveKind.Audio))
                {
                    youTubeVideo = list.MaxBy(e => e.ContentLength);
                }
            }
            else
            {
                youTubeVideo = list.MaxBy(e => e.Resolution);
            }

            return youTubeVideo;
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
