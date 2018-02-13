using System;

namespace QueueManager.Common
{
    public interface IApiClient : IDisposable
    {
        IApiClient Create(string userName, string password);
        void AddHeader(string key, string value);
        TResponse GetSync<TResponse>(Uri uri) where TResponse : class;
    }
}