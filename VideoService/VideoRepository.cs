using Contract;
using System.Collections.Generic;
using System.Threading;

namespace VideoService
{
    public class VideoRepository
    {
        private readonly IDictionary<int, Metadata> _metadata;
        private readonly IDictionary<int, Bookmark> _bookmark;
        private readonly IDictionary<int, Rating> _rating;
        private readonly IList<Video> _videos;

        public VideoRepository()
        {
            _videos = new List<Video>()
            {
                new Video(1, ""),
                new Video(2, ""),
                new Video(3, ""),
                new Video(4, ""),
                new Video(5, "")
            };

            _metadata = new Dictionary<int, Metadata> {
                [1] = new Metadata("", new List<string>(), 0),
                [2] = new Metadata("", new List<string>(), 0),
                [3] = new Metadata("", new List<string>(), 0),
                [4] = new Metadata("", new List<string>(), 0),
                [5] = new Metadata("", new List<string>(), 0)
            };

            _bookmark = new Dictionary<int, Bookmark> {
                [1] = 100,
                [2] = 999,
                [3] = 0,
                [4] = 028,
                [5] = 339
            };

            _rating = new Dictionary<int, Rating> {
                [1] = new Rating(4, 4, 3),
                [2] = new Rating(3, 4, 2),
                [3] = new Rating(2, 5, 5),
                [4] = new Rating(3, 3, 3),
                [5] = new Rating(1, 2, 1)
            };
        }

        public Metadata Metadata(int videoId)
        {
            Thread.Sleep(500);
            return _metadata[videoId];
        }

        public Bookmark Bookmarks(int videoId)
        {
            Thread.Sleep(500);
            return _bookmark[videoId];
        }

        public Rating Rating(int videoId)
        {
            Thread.Sleep(500);
            return _rating[videoId];
        }

        public IEnumerable<Video> Videos()
        {
            Thread.Sleep(500);
            return _videos;
        }
    }
}
