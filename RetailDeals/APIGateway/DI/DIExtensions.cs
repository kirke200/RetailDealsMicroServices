using Microsoft.Extensions.DependencyInjection;
using RetailOffers.MessagingUtilities;
using RetailOffers.MessagingUtilities.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.DI
{
    public static  class DIExtensions
    {
        public static void InjectServices(this IServiceCollection services)
        {
            //Messaging
            services.AddSingleton<IMessagingLogger, MessagingLogger>();

            //Event sender
            services.AddSingleton<IEventSender, RabbitMqSender>();
        }
    }
}
