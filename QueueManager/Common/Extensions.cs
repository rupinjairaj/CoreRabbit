using Newtonsoft.Json;

namespace QueueManager.Common
{
    public static class Extensions
    {
        public static TObject FromJson<TObject>(this string data)
        {
            return JsonConvert.DeserializeObject<TObject>(data);
        }
    }

}