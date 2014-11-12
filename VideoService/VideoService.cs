using Microsoft.Owin.Hosting;
using System;

namespace VideoService
{
    class VideoService
    {
        private IDisposable _host;

        public void Start()
        {
            _host = WebApp.Start<Startup>("http://+:1234");
        }

        public void Stop()
        {
            _host.Dispose();
        }
    }
}
