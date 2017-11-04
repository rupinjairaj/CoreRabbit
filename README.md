# CoreRabbit

A .NET Core 2.0 based project with RabbitMQ samples and a quick setup app for RabbitMQ brokers.

[QuickRabbit](https://github.com/rupinjairaj/CoreRabbit/tree/master/QuickRabbit "QuickRabbit") is a cross platform helper app to setup RabbitMQ brokers.

## Getting Started

For a quick test run, do any one of the following: 
* Install RabbitMQ in your development machine.
* Use a Docker image and run the RabbitMQ Docker container
* Use a RabbitMQ service provider like CloudAMQP.

I recommend using a Docker container as it's much easier to setup and faster to run.

If you don't already have Docker installed go to [Install Docker](https://docs.docker.com/engine/installation/ "Install Docker") and follow the steps for your operating system.

After having installed and verified your Docker setup run the following command to pull the official RabbitMQ Docker image and spin up a container.

```
$ docker run -d --hostname [provide a hostname] --name [provide a container-name] -p 15672:15672 -p 5672:5672 rabbitmq:3-management
```

After that go to http://localhost:15672/#/ and if everything went well with your setup it should open up the RabbitMQ Management console login page.
Enter the username as "guest" and password as "guest" and click login.