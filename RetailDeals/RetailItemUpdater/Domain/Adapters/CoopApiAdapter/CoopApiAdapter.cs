using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.Adapters.CoopApiAdapter
{
    public partial class CoopApiAdapter
    {
        private readonly HttpClient _client = new HttpClient();
    }
}
