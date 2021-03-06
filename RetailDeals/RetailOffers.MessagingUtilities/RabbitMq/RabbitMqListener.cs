﻿using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using RetailOffers.MessagingUtilities.Attributes;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Extensions.Configuration;

namespace RetailOffers.MessagingUtilities.RabbitMq
{
    public class RabbitMqListener<TEvent> : IRabbitMqListener<TEvent> where TEvent : IEvent 
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IMessagingLogger _logger;
        private readonly IConfiguration _configuration;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;
        private static int numberOfTimesToRetryConnection = 5;
        public RabbitMqListener(IServiceProvider serviceProvider, IMessagingLogger logger, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
            _configuration = configuration;
        }

        public void SubscribeEvent()
        {
            var eventReceiver = _serviceProvider.GetService<IEventReceiver<TEvent>>();
            var timesTried = 0;
            try
            {
                _factory = new ConnectionFactory() { HostName = _configuration.GetValue<string>("RabbitMq_UrlName") }; //TODO: Change hostname to not be hardcoded. For some reason this has to be "localhost" if you run it manually but "rabbitmq" when running with docker
                _connection = _factory.CreateConnection();
                _channel = _connection.CreateModel();

                var queueName = GetQueueName();
                _channel.QueueDeclare(queue: queueName,
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += async (model, ea) =>
                {
                    var message = System.Text.Encoding.UTF8.GetString(ea.Body.ToArray());
                    var messageAsEvent = JsonConvert.DeserializeObject<TEvent>(message);
                    await TryHandleAsync(messageAsEvent, () => eventReceiver.ReceiveEvent(messageAsEvent));

                };
                _channel.BasicConsume(queue: queueName,
                                        autoAck: true,
                                        consumer: consumer);

                Console.WriteLine("Listening on queue " + queueName);

            } catch (RabbitMQ.Client.Exceptions.BrokerUnreachableException e)
            {
                if (timesTried >= numberOfTimesToRetryConnection) throw e;
                //Retry after 5 seconds. This is because rabbitmq can be slow on startup.
                timesTried++;
                Thread.Sleep(5000);
                SubscribeEvent();

            }

        }

        public void Deregister()
        {
            _connection.Close();
        }

        private async Task TryHandleAsync(TEvent eventToHandle, Func<Task> receiver)
        {
            _logger.Info($"Handling event {eventToHandle}");

            await receiver();
        }

        //TODO: Make this generic method for core project?
        private string GetQueueName()
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
