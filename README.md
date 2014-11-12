RxMovies
========

Async REST orchestration of a Video server using [Rx](http://rx.codeplex.com/).

Written with C# v6 (Visual Studio 2015 Preview/November 2014).

Usage
-----

On startup, both RxMovies and VideoService should be started (choose multiple startup projects in the solution's property pages).

In RxMovies.Program, uncomment the ```RunSync()``` calls and comment out the ```RunAsync()``` calls to see the difference.

It's also a good idea to run [Fiddler](http://www.telerik.com/fiddler) to see the difference between synchronous execution and asynchronous execution.

Latency is simulated inside each REST endpoint by a simple ```Thread.Sleep()```. 
Alternatively, you could [simulate modem speeds](http://www.campusmvp.net/blog/simulating-a-slow-connection-with-fiddler) with Fiddler.

Notes
-----

Self-hosted with Owin. Nancy self-host appears to serialize all requests, or at least reduce concurrency drastically.