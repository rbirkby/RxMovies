using Contract;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;

namespace Sdk
{
    public class VideoClientAsync
    {
        private readonly IRestClient _restClient;

        public VideoClientAsync(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public IObservable<Video> Videos()
        {
            return _restClient.ExecuteGetTaskAsync<List<Video>>(new RestRequest())
                .ToObservable()
                .SelectMany(response =>
                {
                    if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                        throw new Exception(response.ErrorMessage);

                    return response.Data.ToObservable();
                });
        }

        public IObservable<Metadata> Metadata(int videoId)
        {
            var request = new RestRequest("metadata/" + videoId);
            return _restClient.ExecuteGetTaskAsync<Metadata>(request)
                .ToObservable()
                .Select(response =>
                {
                    if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                        throw new Exception(response.ErrorMessage);

                    return response.Data;
                });
        }

        public IObservable<Bookmark> Bookmark(int videoId)
        {
            var request = new RestRequest("bookmark/" + videoId);
            return _restClient.ExecuteGetTaskAsync<Bookmark>(request)
                .ToObservable()
                .Select(response =>
                {
                    if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                        throw new Exception(response.ErrorMessage);

                    return response.Data;
                });
        }

        public IObservable<Rating> Rating(int videoId)
        {
            var request = new RestRequest("rating/" + videoId);
            return _restClient.ExecuteGetTaskAsync<Rating>(request)
                .ToObservable()
                .Select(response =>
                {
                    if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                        throw new Exception(response.ErrorMessage);

                    return response.Data;
                });
        }
    }
}
