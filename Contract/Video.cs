namespace Contract
{
    public class Video
    {
        public int VideoId { get; private set; }
        public string Title { get; private set; }

        public Video() { }

        public Video(int videoId, string title)
        {
            VideoId = videoId;
            Title = title;
        }
    }
}