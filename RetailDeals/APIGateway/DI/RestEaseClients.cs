using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGateway.Services;
using RestEase;
using RestEase.HttpClientFactory;
using Microsoft.Extensions.Configuration;
using APIGateway.Configuration;

namespace APIGateway.DI
{
    public static class RestEaseClients
    {
        public static void AddRestEaseClients(this IServiceCollection services, RestEaseSettings restEaseSettings)
        {
            var retailItemUpdaterService = restEaseSettings.Services.First(x => x.Name == "retailitemupdater-service");
            services.AddRestEaseClient<IRetailGroupService>($"{retailItemUpdaterService.Scheme}://{retailItemUpdaterService.Host}:{retailItemUpdaterService.Port}");
            services.AddRestEaseClient<IShoppingListService>($"{retailItemUpdaterService.Scheme}://{retailItemUpdaterService.Host}:{retailItemUpdaterService.Port}");
        }
    }
}

