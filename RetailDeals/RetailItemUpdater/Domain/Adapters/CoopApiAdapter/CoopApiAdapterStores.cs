using Microsoft.AspNetCore.Http;
using RetailItemUpdater.Domain.Adapters.Abstractions.CoopApi;
using RetailItemUpdater.Domain.Adapters.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace RetailItemUpdater.Domain.Adapters.CoopApiAdapter
{
    public partial class CoopApiAdapter : ICoopStoreApi
    {
        private readonly IConfiguration _configuration;

        public CoopApiAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RetailGroupsDTO> GetAllRetailGroups()
        {
            Console.WriteLine("Getting stores from coop");
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _configuration["Coop_SubscriptionKey"]); //TODO: Add to appsettings!!
            var uri = _configuration["Coop_Url"];

            var response = await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<RetailGroupsDTO>(new[] { new JsonMediaTypeFormatter() });
            }

            return null;
        }
    }
}
