RxMovies
========

Demonstration of asynchronous REST orchestration of a Video server using [Rx](http://rx.codeplex.com/).

Provides a comparison of non-async REST calls versus RX-orchestrated async calls, showing how latency kills performance.

Written with C# v6 (Visual Studio 2015 Preview/November 2014) in a microservice-style with the REST API running in [Nancy](http://nancyfx.org/), self-hosted on [Katana](https://katanaproject.codeplex.com/) via [Owin](http://owin.org/).

Heavily inspired by the NetFlix [example](https://gist.github.com/benjchristensen/4679246).

Usage
-----

On startup, both RxMovies and VideoService should be started (choose multiple startup projects in the solution's property pages).

There are 3 different implementations:
* ```RunSync()``` - Synchronous HTTP requests
* ```RunTask()``` - Asynchronous HTTP requests, orchestrated by async/await
* ```RunAsync()``` - Asynchronous HTTP requests, orchestrated by Rx

To change between implementations, simply comment/uncomment the appropriate calls in RxMovies.Program.

It's also a good idea to run [Fiddler](http://www.telerik.com/fiddler) to see the difference between synchronous execution and asynchronous execution.

Latency is simulated inside each REST endpoint by a simple ```Thread.Sleep()```. 
Alternatively, you could [simulate modem speeds](http://www.campusmvp.net/blog/simulating-a-slow-connection-with-fiddler) with Fiddler.

In the RunTask implementation, the use of ```Parallel.ForEach()``` causes the lambda to be run on multiple threads. In a server-based environment, this 
may cause unnecessary context switching or thread starvation. Due to Rx in the RunAsync implementation, all subscription callbacks are serialized.

Notes
-----

Self-hosted with Owin. Nancy self-host appears to serialize all requests, or at least reduce concurrency drastically.
