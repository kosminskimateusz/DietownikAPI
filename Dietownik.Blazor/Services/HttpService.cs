using System.Net;
using System.Net.Http.Json;

namespace Dietownik.Blazor.Services
{
    public class HttpService : IhttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(
            HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public Task<T> Get<T>(string uri)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, uri);
            return SendRequest<T>(request);
        }

        private async Task<T> SendRequest<T>(HttpRequestMessage request)
        {
            // add basic auth header if user is logged in and request is to the api url
            
            var isApiUrl = !request.RequestUri.IsAbsoluteUri;
            

            using var response = await _httpClient.SendAsync(request);

            // auto logout on 401 response
            

            // throw exception on error response
            if (!response.IsSuccessStatusCode)
            {
                var error = await response.Content.ReadFromJsonAsync<Dictionary<string, string>>();
                throw new Exception(error["message"]);
            }

            var result = await response.Content.ReadFromJsonAsync<Response<T>>();
            return result.Data;
        }
    }
}
