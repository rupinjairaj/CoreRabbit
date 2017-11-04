using System;
using System.IO;
using QuickRabbit.Models;
using QuickRabbit.Utilities;
using RabbitMQ.Client;

namespace QuickRabbit
{
    class QuickRabbit
    {
        private static IConnection GetRabbitConnection(ConnectionModel cm)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory();
            connectionFactory.Port = cm.Port;
            connectionFactory.HostName = cm.HostName;
            connectionFactory.UserName = cm.UserName;
            connectionFactory.Password = cm.Password;
            connectionFactory.VirtualHost = cm.VHost;
            IConnection connection = null;
            Console.WriteLine("Creating the connection...");
            try
            {
                connection = connectionFactory.CreateConnection();
                if (connection.IsOpen)
                {
                    Console.WriteLine("Connection successfully established!");
                }
                else
                {
                    Console.WriteLine("Something went wrong!");
                }
            }
            catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException exception)
            {
                Console.WriteLine(exception.Message);
            }
            return connection;
        }

        private static void CloseRabbitConnection(IConnection connection)
        {
            Console.WriteLine("Closing the connection...");
            connection.Close();
            if (!connection.IsOpen)
            {
                Console.WriteLine("Connection successfully closed!");
            }
            else
            {
                Console.WriteLine("Error in closing the connection!");
            }
        }

        private static IModel GetRabbitChannel(IConnection connection)
        {
            Console.WriteLine("Creating the channel...");
            IModel channel = connection.CreateModel();
            if (channel.IsOpen)
            {
                Console.WriteLine("Channel successfully created!");
            }
            else
            {
                Console.WriteLine("Error in creating the channel!");
            }
            return channel;
        }

        private static void CloseRabbitChannel(IModel channel)
        {
            Console.WriteLine("Closing the channel...");
            channel.Close();
            if (channel.IsClosed)
            {
                Console.WriteLine("Channel successfully closed!");
            }
            else
            {
                Console.WriteLine("Error in closing the channel!");
            }
        }

        private static IModel DeclareRabbitExchange(IModel channel, ExchangeModel exchangeModel)
        {
            Console.WriteLine("Creating the Exchange...");
            channel.ExchangeDeclare
            (
                exchange: exchangeModel.Name,
                type: exchangeModel.Type,
                durable: exchangeModel.Durable,
                autoDelete: exchangeModel.AutoDelete,
                arguments: exchangeModel.Arguments
            );
            Console.WriteLine("Exchange created!");
            return channel;
        }

        private static IModel DeclareRabbitQueue(IModel channel, QueueModel queueModel)
        {
            Console.WriteLine("Creating the Queue...");
            channel.QueueDeclare
            (
                queue: queueModel.Name,
                durable: queueModel.Durable,
                exclusive: queueModel.Exclusive,
                autoDelete: queueModel.AutoDelete,
                arguments: queueModel.Arguments
            );
            Console.WriteLine("Queue created!");
            return channel;
        }

        private static IModel CreateQueueExchangeBinding(IModel channel, QueueExchangeBindingModel queueExchangeBindingModel)
        {
            Console.WriteLine("Binding the Queue and Exchange...");
            channel.QueueBind
            (
                queue: queueExchangeBindingModel.QueueName,
                exchange: queueExchangeBindingModel.ExchangeName,
                routingKey: queueExchangeBindingModel.RoutingKey
            );
            Console.WriteLine("Binding created between the Exchange and Queue!");
            return channel;
        }

        static void Main(string[] args)
        {
            // Get the JSON file.
            /*
            ** Let the location of the JSON file if not provided as an argument be the pwd of the program
            ** [REQUIRED] filename has to be -> Quick.json 
             */
            string x;
            if (args.Length == 0)
            {
                x = (Directory.GetCurrentDirectory() + "/Quick.json");
            }
            else
            {
                x = args[0];
            }

            /*
            ** Read Quick.json and Parse it. 
            */
            JSONParser jParser = new JSONParser();
            var json = jParser.JSONFileReader(x);

            /*
            ** Map each JToken to its corresponding RabbitMQ object, for example the ConnectionModel object
             */
            JSONMapper jMapper = new JSONMapper();
            var connectionModel = jMapper.BuildConnectionObject(json["ConnectionModel"]);
            var connection = GetRabbitConnection(connectionModel);
            var channel = GetRabbitChannel(connection);

            var exchangeModel = jMapper.BuildExchangeModel(json["ExchangeModel"]);
            channel = DeclareRabbitExchange(channel, exchangeModel);

            var queueModel = jMapper.BuildQueueModel(json["QueueModel"]);
            channel = DeclareRabbitQueue(channel, queueModel);

            var queueExchangeBindingModel = jMapper.BuildQueueExchangeBindingModel(json["QueueExchangeBindingModel"]);
            channel = CreateQueueExchangeBinding(channel, queueExchangeBindingModel);

            CloseRabbitChannel(channel);
            CloseRabbitConnection(connection);
            Console.Read();
        }
    }
}
