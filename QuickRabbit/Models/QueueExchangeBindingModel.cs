namespace QuickRabbit.Models
{
    class QueueExchangeBindingModel
    {
        public string QueueName { get; set; }
        public string ExchangeName { get; set; }
        public string RoutingKey { get; set; }
    }
}