﻿using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Shared;
using System.Text;
using System.Text.Json;

namespace RabbitMQ.Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            //if we have a cloud rabbitmq we must use this method in Connection 
            //var factory = new ConnectionFactory() {factory.uri = new Uri("Cloud Link")}

            var factory = new ConnectionFactory()//Connect RabbitMQ with Docker Container.
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            using var connection = factory.CreateConnection();

            var channel = connection.CreateModel();
            channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);//if u open first subscribe u must crate a exchange for dont be error

            channel.BasicQos(0, 1, false);//=> this "false" , answer to whether or not the specified number of messages should be sent to subscribers by dividing them. 

            /* channel.QueueDeclare("hello-queue", true, false, false);*///if u have same queue in publisher this method unncessary but harmless , and u must use same options for queue.

            var consumer = new EventingBasicConsumer(channel);
            var queueName = channel.QueueDeclare().QueueName;

            Dictionary<string,object> headers = new Dictionary<string, object>();
            headers.Add("format", "pdf");
            headers.Add("shape", "a4");
            headers.Add("x-match", "all");//if we use the "x-match" "all" method publisher and subscriber must have same headers but if we use "x-match"  "any"  just one headers match eneough for it.


            channel.QueueBind(queueName,"header-exchange" , string.Empty,headers);

            channel.BasicConsume(queueName, false, consumer);

            Console.WriteLine("listening...");

            consumer.Received += (object? sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());

                Product product = JsonSerializer.Deserialize<Product>(message);

                Thread.Sleep(1500);
                Console.WriteLine($"Uyarı: {product.Id}-{product.Name}-{product.price}-{product.stock}");
                //File.AppendAllText("log-critical.txt", message + "\n");
                channel.BasicAck(e.DeliveryTag, false);
            };




            Console.ReadLine();
        }


    }
}