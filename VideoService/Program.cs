using Topshelf;

namespace VideoService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<VideoService>(s =>
                {
                    s.ConstructUsing(_ => new VideoService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                x.RunAsLocalSystem();
            });
        }
    }
}
