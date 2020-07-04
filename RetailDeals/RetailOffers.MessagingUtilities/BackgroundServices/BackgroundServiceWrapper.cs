using Microsoft.Extensions.Hosting;
using RetailOffers.MessagingUtilities.RabbitMq;
using System.Threading;
using System.Threading.Tasks;


namespace RetailOffers.MessagingUtilities.BackgroundServices
{
    public class BackgroundServiceWrapper<TEvent> : BackgroundService where TEvent : IEvent
    {

        private static IRabbitMqListener<TEvent> _rabbitMqListener;

        public BackgroundServiceWrapper(IRabbitMqListener<TEvent> rabbitMqListener)
        {
            _rabbitMqListener = rabbitMqListener;
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _rabbitMqListener.Deregister();
            return base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _rabbitMqListener.SubscribeEvent();

            return Task.CompletedTask;
        }

    }
}
