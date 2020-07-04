using Microsoft.AspNetCore.Http;
using RetailItemUpdater.Domain.Adapters.Abstractions.CoopApi;
using RetailItemUpdater.Domain.Adapters.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace RetailItemUpdater.Domain.Adapters.CoopApiAdapter
{
    public partial class CoopApiAdapter : ICoopStoreApi
    {
        public async Task<RetailGroupsDTO> GetAllRetailGroups()
        {
            Console.WriteLine("Getting stores from coop");
            _client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "5e8f23af5e7f43ae8ec60e804333e094");
            var uri = "https://apidemo.cl.coop.dk/storeapi/v1/stores/retailGroups";

            var response = (HttpResponseMessage) await _client.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<RetailGroupsDTO>(new[] { new JsonMediaTypeFormatter() });
            }

            return null;
        }
    }
}
