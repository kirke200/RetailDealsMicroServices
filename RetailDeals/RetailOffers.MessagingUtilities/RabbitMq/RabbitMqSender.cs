using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RetailOffers.MessagingUtilities.Attributes;

namespace RetailOffers.MessagingUtilities.RabbitMq
{
    public class RabbitMqSender : IEventSender
    {
        private IMessagingLogger _logger;

        public RabbitMqSender(IMessagingLogger logger)
        {
            _logger = logger;
        }

        public void PublishEvent<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            var factory = new ConnectionFactory() { HostName = "rabbitmq" }; //TODO: Change hostname to not be hardcoded
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var queueName = GetQueueName<TEvent>();
                channel.QueueDeclare(queue: queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonConvert.SerializeObject(eventToPublish);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: queueName, //TODO: Routingkey andet end queuename?
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Published event {0}", message);
            }
        }

        private string GetQueueName<TEvent>() where TEvent : IEvent
        {
            var attribute = (QueueNameAttribute)Attribute.GetCustomAttribute(typeof(TEvent), typeof(QueueNameAttribute));

            if (attribute == null)
            {
                _logger.Error("Failed to get queue name");
                throw new NullReferenceException(nameof(attribute));
            }


            return attribute.Name;
        }
    }
}

