using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RetailItemUpdater.Domain.Adapters.Abstractions.CoopApi;
using RetailItemUpdater.Domain.Adapters.CoopApiAdapter;
using RetailItemUpdater.Domain.DAL.Abstractions;
using RetailItemUpdater.Domain.DAL.InMemoryRepository;
using RetailItemUpdater.Domain.Services;
using RetailItemUpdater.Domain.Services.Abstractions;
using RetailItemUpdater.Events;
using RetailItemUpdater.Events.Receivers;
using RetailOffers.MessagingUtilities;
using RetailOffers.MessagingUtilities.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater
{
    public static class DIExtensions
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddSingleton<IMessagingLogger, MessagingLogger>();

            //Adapters
            services.AddScoped<ICoopStoreApi, CoopApiAdapter>();

            //Event receivers
            services.AddSingleton<IEventReceiver<TestEvent>, TestEventReceiver>();
            services.AddSingleton<IEventReceiver<UpdateRetailGroupsRequested>, UpdateRetailGroupsRequestedReceiver>();

            //Queue listeners
            services.AddSingleton<IRabbitMqListener<TestEvent>, RabbitMqListener<TestEvent>>();
            services.AddSingleton<IRabbitMqListener<UpdateRetailGroupsRequested>, RabbitMqListener<UpdateRetailGroupsRequested>>();

            //Repositories
            services.AddScoped<IRetailGroupsRepository, InMemoryRepository>();

            //Services
            services.AddScoped<IRetailGroupsUpdater, RetailGroupUpdater>();
        }
    }
}
