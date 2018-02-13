using System;
using System.Net.Http;

namespace QueueManager.Common
{
    public interface IApiClient : IDisposable
    {
        IApiClient Create(string userName, string password);
        void AddHeader(string key, string value);
        HttpResponseMessage GetSync(Uri uri);
    }
}