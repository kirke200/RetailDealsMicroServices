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
            var retailGroupService = restEaseSettings.Services.First(x => x.Name == "retailitemupdater-service");
            services.AddRestEaseClient<IRetailGroupService>($"{retailGroupService.Scheme}://{retailGroupService.Host}:{retailGroupService.Port}");
        }
    }
}

