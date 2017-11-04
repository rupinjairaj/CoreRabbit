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
            return JSONConnectionModel.ToObject<ConnectionModel>();
        }

        public ExchangeModel BuildExchangeModel(JToken JSONExchangeModel)
        {
            // Building an ExchangeModel to pass-on to BuildExchangeModel
            return JSONExchangeModel.ToObject<ExchangeModel>();
        }
    }
}