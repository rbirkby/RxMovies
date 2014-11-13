using Contract;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Sdk
{
    public class VideoClientTask
    {
        private readonly IRestClient _restClient;

        public VideoClientTask(string baseUrl)
        {
            _restClient = new RestClient(baseUrl);
        }

        public async Task<List<Video>> Videos()
        {
            var response = await _restClient.ExecuteGetTaskAsync<List<Video>>(new RestRequest());

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public async Task<Metadata> Metadata(int videoId)
        {
            var request = new RestRequest("metadata/" + videoId);
            var response = await _restClient.ExecuteGetTaskAsync<Metadata>(request);

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public async Task<Bookmark> Bookmark(int videoId)
        {
            var request = new RestRequest("bookmark/" + videoId);
            var response = await _restClient.ExecuteGetTaskAsync<Bookmark>(request);

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }

        public async Task<Rating> Rating(int videoId)
        {
            var request = new RestRequest("rating/" + videoId);
            var response = await _restClient.ExecuteGetTaskAsync<Rating>(request);

            if (response.StatusCode != HttpStatusCode.OK || response.Data == null)
                throw new Exception(response.ErrorMessage);

            return response.Data;
        }
    }
}
