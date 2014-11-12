using Sdk;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;

namespace RxMovies
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("...Warming up");
            RunAsync(isWarmup:true);
            //RunSync(isWarmup: true);
            Console.WriteLine("...Warm");

            var stopwatch = Stopwatch.StartNew();
            RunAsync();
            //RunSync();

            Console.WriteLine("Done in {0}ms", stopwatch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        static void RunAsync(bool isWarmup = false)
        {
            var client = new VideoClientAsync(string.Format("http://{0}:1234/", Environment.MachineName));
            var observable = client.Videos()
                .SelectMany(video =>
                {
                    var bookmark = client.Bookmark(video.VideoId);
                    var metadata = client.Metadata(video.VideoId);
                    var rating = client.Rating(video.VideoId);

                    return Observable.Zip(bookmark, metadata, rating, (b, m, r) =>
                    {
                        return new
                        {
                            Id = video.VideoId,
                            m.Title,
                            m.Duration,
                            bookmark = b,
                            rating = r
                        };
                    });
                }).Replay();

            observable.Connect();

            if (!isWarmup)
            {
                observable.Subscribe(Console.WriteLine, onError: Console.Error.WriteLine, onCompleted: () => Console.WriteLine("Complete"));
            }

            observable.LastOrDefaultAsync().Wait();
        }

        static void RunSync(bool isWarmup = false)
        {
            var client = new VideoClient(string.Format("http://{0}:1234/", Environment.MachineName));
            foreach (var video in client.Videos())
            {
                var bookmark = client.Bookmark(video.VideoId);
                var metadata = client.Metadata(video.VideoId);
                var rating = client.Rating(video.VideoId);

                var item = new
                {
                    Id = video.VideoId,
                    metadata.Title,
                    metadata.Duration,
                    bookmark,
                    rating
                };

                if (!isWarmup)
                    Console.WriteLine(item);
            }
        }
    }
}
