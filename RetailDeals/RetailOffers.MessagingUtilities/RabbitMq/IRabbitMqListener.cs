using System.Threading.Tasks;

namespace RetailOffers.MessagingUtilities.RabbitMq
{
    public interface IRabbitMqListener<TEvent>
    {
        void SubscribeEvent();
        void Deregister();
    }
}