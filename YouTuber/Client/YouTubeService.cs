using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using VideoLibrary;

namespace YouTuber.Client
{
    public class YouTubeService : IYouTubeService
    {
        private const string BaseUrl = "https://www.youtube.com/watch?v=";
        private const string BaseFolder = "download";
        private readonly HashSet<string> _set = new HashSet<string>();

        public virtual async Task YoutubeToMp4(IEnumerable<string> urls)
        {
            var options = new ParallelOptions();
            var maxProc = Environment.ProcessorCount;
            options.MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling(maxProc * 1.75));

            var count = 1;

            await Parallel.ForEachAsync(urls, options, async (url, token) =>
            {
                var result = await YoutubeToMp4(url);

                if (!string.IsNullOrWhiteSpace(result))
                {
                    Console.WriteLine($"{count++}- {result}");
                }
            });
        }

        public virtual async Task<string?> YoutubeToMp4(string url)
        {
            var uri = Url(url).ToString();

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

            var validationMessage = ValidateVideo(video);
            if (validationMessage != "OK") return validationMessage;
            
            CreateFolder(BaseFolder);
            var path = Path.Combine(BaseFolder, video.FullName);
            await File.WriteAllBytesAsync(path, await video.GetBytesAsync());
            return $"{CleanFilename(video.FullName)} video is ready and saved under {BaseFolder}";

        }

        private static string ValidateVideo(YouTubeVideo video)
        {
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
                return $"{title} is properly copyright protected or locked by provider!";
            }
            catch (Exception)
            {
                return "Unknown error please report a bug!";
            }

            return "OK";
        }

        public virtual IEnumerable<string> FileToList(string file)
        {
            using var fs = new FileStream(file, FileMode.Open, FileAccess.Read);
            using var sr = new StreamReader(fs);
            var results = sr.ReadToEnd()
                .Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            return results;
        }

        private static void CreateFolder(string folder)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), folder);
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
            var str = url.Length == 11 ? $"{BaseUrl}{url}" : url;
            var uri = new Uri(str);
            return uri;
        }

    }

}
