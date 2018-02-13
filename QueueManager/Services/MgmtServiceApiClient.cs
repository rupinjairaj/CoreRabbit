using QueueManager.Common;

namespace QueueManager.Services
{
    public interface IMgmtServiceApiClient
    {
        IApiClient Create(string userName, string password);
    }

    public class MgmtServiceApiClient : IMgmtServiceApiClient
    {
        private readonly IApiContainer _apiContainer;
        public MgmtServiceApiClient(IApiContainer apiContainer)
        {
            _apiContainer = apiContainer;
        }

        // Add any Mgmt specific headers here 
        public IApiClient Create(string userName, string password)
        {
            var client = _apiContainer.Create(userName, password);
            if(client == null) return null;

            return client;
        }
    }
}