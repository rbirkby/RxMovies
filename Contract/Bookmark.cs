namespace Contract
{
    public class Bookmark
    {
        public int Position { get; private set; }

        public Bookmark() { }

        public Bookmark(int position)
        {
            Position = position;
        }

        public static implicit operator Bookmark(int position)
        {
            return new Bookmark(position);
        }
    }
}