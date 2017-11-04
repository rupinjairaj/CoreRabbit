# QuickRabbit

A .NET Core 2.0 based app that helps setup your RabbitMQ brokers based on the information in a JSON file.

## Motivation

This app was made keeping in mind the DRY principle.
Decide on your Exchanges and Queues and fill in the fields in the required JSON format. Executing the app, providing it the JSON file and let it build your brokers for you.

## Installation
Follow the steps provided in the Getting Started section of the root project [CoreRabbit](https://github.com/rupinjairaj/CoreRabbit#getting-started "CoreRabbit").

## JSON Guidelines
The sample json provided in the project called Quick.json is the JSON structure to follow for successfully running the app.

* ConnectionModel
   This JSON obejct maps to a RabbitMQ IConnection instance.  
   Based on your where your RabbitMQ instance is running, provide the correct values to those attributes to establish a successful connection.
```
    {
        "Port": 5672,
        "HostName": "localhost",
        "UserName": "guest",
        "Password": "guest",
        "VHost": "/"
    }
```
* ExchangeModel
    This JSON object creates an Exchange in the RabbitMQ instance it connected to based on the ConnectionModel details.
```
    {
        "Name": "my.first.exchange",
        "Type": "direct",
        "Durable": true,
        "AutoDelete": false,
        "Arguments": null
    }
```
* QueueModel
    This JSON object creates a Queue in the RabbitMQ instance it connected to using the ConnectionModel provided.
```
    {
        "Name": "my.first.queue",
        "Durable": true,
        "Exclusive": false,
        "AutoDelete": false,
        "Arguments": null
    }
```
* QueueExchangeBindingModel
    Provide this JSON model to create the binding between and Exchange and a Queue
```
    {
        "QueueName": "my.first.queue",
        "ExchangeName": "my.first.exchange",
        "RoutingKey": ""
    }
```

## How to use the app?
* Clone the project into your machine.   
* Open a terminal window and navigate to the the QuickRabbit directory
* Follow the JSON structure mentioned above and create and save a JSON file under the name 'Quick.json'
* If Quick.json is in the same directory as QuickRabbit then you can simply run the program as
```
    dotnet run
``` 
* If Quick.json is in a different location the pass the location of the file as a command line argument
```
    dotnet run [location to Quick.json]
```

## Known Issues
* This version requires .NET Core 2.0 installed on your system.
* Does not support multiple Exchange and Queue declarations at the moment.
* Does not support Exchange to Exchange binding.

## Contact the author
[Rupin Jairaj (Twitter)](https://twitter.com/RupinJairaj "Rupin Jairaj (Twitter)")