using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QuickRabbit.Models;

namespace QuickRabbit.Utilities
{
    class JSONMapper
    {
        public ConnectionModel BuildConnectionObject(JToken JSONConnectionModel)
        {
            // Building a ConnectionModel to pass-on to GetRabbitConnection 
            var cm = JSONConnectionModel.ToObject<ConnectionModel>();
            return cm;
        }
    }
}