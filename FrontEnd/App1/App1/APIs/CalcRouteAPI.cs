using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using App1.Models;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace App1.ConnectionControllers
{
    class CalcRouteAPI
    {
        HttpClient client;


        public CalcRouteAPI()
        {
            client = new HttpClient
        (
            new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    //bypass
                    return true;
                },
            }
            , false
        );
        }


        public async Task<HttpResponseMessage> PostList(MyList list, Brand brand)
        {

            client.BaseAddress = new Uri("http://192.168.0.241:5000/api/RetailGroups?name=Kvickly");

            var parameters = Tuple.Create(list, brand);

            string json = JsonConvert.SerializeObject(parameters);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            //should return list of coordinates to stores, what stores to go to, list of items from what store
            HttpResponseMessage response = null;

            response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {

            }

            //var jsonString = response.Content.ReadAsStringAsync();
            //JsonConvert.DeserializeObject<>
            return response;
        }




    }
}
