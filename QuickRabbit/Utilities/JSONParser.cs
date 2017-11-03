using System.IO;
using Newtonsoft.Json.Linq;

namespace QuickRabbit.Utilities
{
    class JSONParser
    {
        public JObject JSONFileReader(string FilePath)
        {
            JObject JSONObject = JObject.Parse(File.ReadAllText(FilePath));
            return JSONObject;
        }
    }
}