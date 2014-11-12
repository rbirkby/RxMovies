using System.Collections.Generic;

namespace Contract
{

    public class Metadata
    {
        public string Title { get; private set; }
        public List<string> Actors { get; private set; }
        public decimal Duration { get; private set; }

        public Metadata() { }

        public Metadata(string title, List<string> actors, decimal duration)
        {
            Title = title;
            Actors = actors;
            Duration = duration;
        }
    }
}