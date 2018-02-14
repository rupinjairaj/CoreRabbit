using System;
using QueueManager.AuthLib;
using QueueManager.Common;
using QueueManager.Services;

namespace QueueManager.Core
{
    public interface IMgmt
    {
        string GetConsumers();
    }

    public class Mgmt : IMgmt
    {
        private readonly IMgmtServiceApiClient _mgmtServiceApiClient;
        public Mgmt(IMgmtServiceApiClient mgmtServiceApiClient)
        {
            _mgmtServiceApiClient = mgmtServiceApiClient;
        }
        public string GetConsumers()
        {
            string result;
            var uri = new Uri(QueueManagerConstants.BaseUrl + QueueManagerConstants.Consumers);
            using (var client = _mgmtServiceApiClient.Create(userName: Auth.UserName, password: Auth.Password))
            {
                var response = client.GetSync(uri);
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }
    }
}