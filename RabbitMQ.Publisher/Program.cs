using RabbitMQ.Client;
using System.Text;

namespace RabbitMQ.Publisher
{
    class Program
    {
        public enum LogNames
        {
            Critical = 1,
            Error = 2,
            Warning = 3,
            Info = 4,

        }


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

            channel.ExchangeDeclare("header-exchange", durable: true, type: ExchangeType.Headers);

            Dictionary<string, object> headers = new Dictionary<string, object>();

            headers.Add("format", "pdf");
            headers.Add("shape4", "a4");
            headers.Add("x-match", "all");

            var properties = channel.CreateBasicProperties();
            properties.Headers=headers;


            channel.BasicPublish("header-exchange", string.Empty, properties, Encoding.UTF8.GetBytes("header mesajım"));

            Console.WriteLine("Mesaj Gönderilmiştir");

            Console.ReadLine();
        }
    }
}
