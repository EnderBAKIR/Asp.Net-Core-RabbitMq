﻿
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQWaterMark_WEB.APP.Services;
using System.Drawing;
using System.Text;
using System.Text.Json;

namespace RabbitMQWaterMark_WEB.APP.BackgroundServices
{
    public class ImageWaterMarkProcessBackGroundService : BackgroundService
    {

        private readonly RabbitMQClientService _rabbitmqClientService;
        private readonly ILogger<ImageWaterMarkProcessBackGroundService> _logger;
        private IModel _channel;

        public ImageWaterMarkProcessBackGroundService(RabbitMQClientService rabbitmqClientService, ILogger<ImageWaterMarkProcessBackGroundService> logger)
        {
            _rabbitmqClientService = rabbitmqClientService;
            _logger = logger;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            _channel = _rabbitmqClientService.Connect();

            _channel.BasicQos(0, 1, false);

            return base.StartAsync(cancellationToken);
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
           var consumer = new AsyncEventingBasicConsumer(_channel);

            _channel.BasicConsume(RabbitMQClientService.QueueName,false,consumer);

            consumer.Received += Consumer_Received;


            return Task.CompletedTask;

        }

        private  Task Consumer_Received(object sender, BasicDeliverEventArgs @event)
        {
            Task.Delay(4500).Wait();
            try
            {
                var productimageCreatedEvent = JsonSerializer.Deserialize<ProductImageCreatedEvent>(Encoding.UTF8.GetString(@event.Body.ToArray()));

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", productimageCreatedEvent.ImageName);
               
                var siteName = "www.RabbitMQMarkProduct.com";

                using var img = Image.FromFile(path);

                using var graphic = Graphics.FromImage(img);

                var font = new Font(FontFamily.GenericMonospace, 42 , FontStyle.Bold, GraphicsUnit.Pixel);

                var textSize = graphic.MeasureString(siteName, font);

                var color = Color.FromArgb(128, 255, 255, 255);

                var brush = new SolidBrush(color);

                var position = new Point(img.Width - ((int)textSize.Width + 30), img.Height - ((int)textSize.Height + 30));

                graphic.DrawString(siteName, font, brush, position);

                img.Save("wwwroot/images/watermarks/" + productimageCreatedEvent.ImageName);

                img.Dispose();
                graphic.Dispose();

                _channel.BasicAck(@event.DeliveryTag, false);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex.Message);
            }
            return Task.CompletedTask;

        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            return base.StopAsync(cancellationToken);
        }
    }
}
