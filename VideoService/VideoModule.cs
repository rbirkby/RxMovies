using Nancy;

namespace VideoService
{
    public class VideoModule : NancyModule
    {
        public VideoModule(VideoRepository repository)
        {
            Get["/"] = _ => Response.AsJson(repository.Videos());
            Get["/metadata/{videoId:int}"] = parameters => Response.AsJson(repository.Metadata((int)parameters.videoId));
            Get["/bookmark/{videoId:int}"] = parameters => Response.AsJson(repository.Bookmarks((int)parameters.videoId));
            Get["/rating/{videoId:int}"] = parameters => Response.AsJson(repository.Rating((int)parameters.videoId));
        }
    }
}
