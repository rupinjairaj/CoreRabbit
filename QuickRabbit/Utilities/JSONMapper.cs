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
            // Building an ExchangeModel to pass-on to DeclareRabbitExchange
            return JSONExchangeModel.ToObject<ExchangeModel>();
        }

        public QueueModel BuildQueueModel(JToken JSONQueueModel)
        {
            // Building a QueueModel to pass-on to DeclareRabbitQueue
            return JSONQueueModel.ToObject<QueueModel>();
        }

        public QueueExchangeBindingModel BuildQueueExchangeBindingModel(JToken JSONQueueExchangeBindingModel)
        {
            // Building a BuildQueueExchangeBindingModel to pass-on to CreateQueueExchangeBinding
            return JSONQueueExchangeBindingModel.ToObject<QueueExchangeBindingModel>();
        }
    }
}