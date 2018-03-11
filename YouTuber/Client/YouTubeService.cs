using System;
using System.IO;
using MediaToolkit;
using VideoLibrary;
using MediaToolkit.Model;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace YouTuber.Client
{
    public class YouTubeService : IYouTubeService
    {
        private const string BaseUrl = "https://www.youtube.com/watch?v=";
        private const string BaseFolder = "download";
        private readonly HashSet<string> _set = new HashSet<string>();

        public virtual void YoutubeToMp3(IEnumerable<string> urls)
        {
            var parallelOptions = new ParallelOptions();
            var maxProc = Environment.ProcessorCount;
            parallelOptions.MaxDegreeOfParallelism = Convert.ToInt32(Math.Ceiling(maxProc * 1.75));
            var count = 1;
            Parallel.ForEach(urls, parallelOptions, url =>
            {
                var result = YoutubeToMp3(url);
                if (!string.IsNullOrWhiteSpace(result))
                    Console.WriteLine($"{count++}- {result}");
            });
        }

        public virtual string YoutubeToMp3(string url)
        {
            var uri = Url(url).ToString();

            if (uri.Replace(BaseUrl, "").Length != 11)
            {
                return "Looks like this is invalid url/id";
            }

            if (_set.Contains(url))
            {
                return null;
            }

            lock(_set){
                _set.Add(url);
            }

            var youtube = YouTube.Default;
            var video = youtube.GetVideoAsync(uri);

            try
            {
                var getUri = video.Result.Uri;
            }
            catch (AggregateException ignore)
            {
                return "Looks like this is invalid url/id";
            }
            catch (InvalidOperationException ignore)
            {
                return
                    $"{CleanFilename(video.Result.FullName)} video is properly copyright protected or locked by provider!";
            }
            catch (Exception ignore)
            {
                return "Unknown error please report a bug!";
            }
            
            CreateFolder(BaseFolder);

            File.WriteAllBytes(video.Result.FullName, video.Result.GetBytes());

            var inputFile = new MediaFile {Filename = video.Result.FullName};
            var outputFile = new MediaFile {Filename = $"{BaseFolder}\\{CleanFilename(video.Result.FullName)}.mp3"};

            using (var engine = new Engine())
            {
                engine.GetMetadata(inputFile);
                engine.Convert(inputFile, outputFile);
            }

            TryToDelete(inputFile.Filename);
            return
                $"{CleanFilename(video.Result.FullName)} sound is ready and saved under {BaseFolder}";
        }

        public virtual IEnumerable<string> FileToList(string file)
        {
            string[] results;
            using (var fs = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                using (var sr = new StreamReader(fs))
                {
                    results = sr.ReadToEnd().Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries);
                }
            }
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

        private static void TryToDelete(string file)
        {
            try
            {
                File.Delete(file);
            }
            catch (IOException ex)
            {
            }
        }
    }
}