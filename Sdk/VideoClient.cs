using Contract;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;

namespace Sdk
{
    public class VideoClient
    {
        private readonly IRestClient _restClient;

        public VideoClient(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public List<Video> Videos()
        {
            var response = _restClient.Get<List<Video>>(new RestRequest());

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public Metadata Metadata(int videoId)
        {
            var request = new RestRequest("metadata/" + videoId);
            var response = _restClient.Get<Metadata>(request);

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public Bookmark Bookmark(int videoId)
        {
            var request = new RestRequest("bookmark/" + videoId);
            var response = _restClient.Get<Bookmark>(request);

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public Rating Rating(int videoId)
        {
            var request = new RestRequest("rating/" + videoId);
            var response = _restClient.Get<Rating>(request);

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }
    }
}
