using Microsoft.Extensions.DependencyInjection;
using RetailItemUpdater.Events;

using RetailOffers.MessagingUtilities.BackgroundServices;


namespace RetailItemUpdater.DI
{
    public static class HostedServices
    {
        public static void SubscribeToQueues(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddHostedService<BackgroundServiceWrapper<TestEvent>>();
            serviceCollection.AddHostedService<BackgroundServiceWrapper<UpdateRetailGroupsRequested>>();
        }
    }
}
