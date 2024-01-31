using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

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

            channel.QueueDeclare("hello-queue", true, false, false);//if u have same queue in publisher this method unncessary but harmless , and u must use same options for queue.

            var consumer = new EventingBasicConsumer(channel);

            channel.BasicConsume("hello-queue", true, consumer);

            consumer.Received += (object? sender, BasicDeliverEventArgs e) =>
            {
                var message = Encoding.UTF8.GetString(e.Body.ToArray());

                Console.WriteLine("Uyarı" + message);
            };




            Console.ReadLine();
        }

      
    }
}