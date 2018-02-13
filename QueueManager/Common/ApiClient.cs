using System;
using System.Net;
using System.Net.Http;

namespace QueueManager.Common
{
    public class ApiClient : IApiClient
    {
        private HttpClient _httpClient;
        private bool _disposed;

        public void AddHeader(string key, string value)
        {
            _httpClient.DefaultRequestHeaders.Add(key, value);
        }

        public IApiClient Create(string userName, string password)
        {
            var httpClientHandler = new HttpClientHandler
            {
                Credentials = new NetworkCredential(userName, password)
            };
            _httpClient = new HttpClient(httpClientHandler)
            {
                Timeout = TimeSpan.FromSeconds(QueueManagerConstants.DefaultApiTimeOut),
            };
            return this;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed || !disposing) return;
            if (_httpClient != null)
            {
                var hc = _httpClient;
                _httpClient = null;
                hc.Dispose();
            }

            _disposed = true;
        }

        public TResponse GetSync<TResponse>(Uri uri) where TResponse : class
        {
            var response = _httpClient.GetAsync(uri).Result;
            return response.Content.ReadAsStringAsync().Result.FromJson<TResponse>();
        }
    }
}