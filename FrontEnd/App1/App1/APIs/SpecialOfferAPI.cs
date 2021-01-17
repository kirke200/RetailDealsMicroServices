using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.ConnectionControllers
{
    class SpecialOfferAPI
    {
        HttpClient client;

        public SpecialOfferAPI()
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

        public async Task<HttpResponseMessage> PostSpecialOffer(SpecialOffer so)
        {

            client.BaseAddress = new Uri(Config.ConnectionConfig.GetAPIBaseAdress());

            string json = JsonConvert.SerializeObject(so);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


            HttpResponseMessage response = null;

            response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {

            }

            //var jsonString = response.Content.ReadAsStringAsync();
            //JsonConvert.DeserializeObject<>
            return response;
        }

        public async Task<HttpResponseMessage> GetOffers()
        {

            client.BaseAddress = new Uri(Config.ConnectionConfig.GetAPIBaseAdress());
            var so = new List<SpecialOffer>();

            HttpResponseMessage response = null;

            response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                so = JsonConvert.DeserializeObject<List<SpecialOffer>>(content);
            }

            //var jsonString = response.Content.ReadAsStringAsync();
            //JsonConvert.DeserializeObject<>
            return response;
        }
    }
}
