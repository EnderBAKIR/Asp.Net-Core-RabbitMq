using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ.Publisher
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

            channel.QueueDeclare("hello-queue" , true , false , false);

            string message = "hello rabbit";
            var messagebody=Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(string.Empty, "hello-queue", null, messagebody);

            Console.WriteLine("Mesaj Gönderilmiştir");
            Console.ReadLine();
        }
    }
}
