namespace QueueManager.Common
{
    public interface IApiContainer
    {
        IApiClient Create(string userName, string password);
    }

    public class ApiContainer : IApiContainer
    {
        private readonly IApiClient _apiClient;
        public ApiContainer(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        IApiClient IApiContainer.Create(string userName, string password)
        {
            return _apiClient.Create(userName, password);
        }
    }
}