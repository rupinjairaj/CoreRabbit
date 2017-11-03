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
            connectionFactory.Port = cm.PORT;
            connectionFactory.HostName = cm.HOSTNAME;
            connectionFactory.UserName = cm.USERNAME;
            connectionFactory.Password = cm.PASSWORD;
            connectionFactory.VirtualHost = cm.VHOST;
            return connectionFactory.CreateConnection();
        }

        private static IConnection CloseRabbitConnection(IConnection connection)
        {
            connection.Close();
            return connection;
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
            if (connection.IsOpen)
            {
                Console.WriteLine("Connection is open");
            }
            else
            {
                Console.WriteLine("Error connecting to RabbitMQ");
            }
            Console.WriteLine("Closing connection...");
            connection.Close();
            if (!connection.IsOpen)
            {
                Console.WriteLine("Connection closed!");
            }
            else
            {
                Console.WriteLine("Error closing connection!");
            }
            Console.ReadKey();
        }
    }
}
