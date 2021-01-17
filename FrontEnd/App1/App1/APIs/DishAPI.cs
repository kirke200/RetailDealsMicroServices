using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.ConnectionControllers
{
    class DishAPI
    {

        HttpClient client;

        public DishAPI()
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



        public async Task<HttpResponseMessage> GetDishes()
        {

            client.BaseAddress = new Uri("http://192.168.0.241:5000/api/RetailGroups?name=Kvickly");
            var dishes = new List<Dish>();

            HttpResponseMessage response = null;

            response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                dishes = JsonConvert.DeserializeObject<List<Dish>>(content);
            }

            //var jsonString = response.Content.ReadAsStringAsync();
            //JsonConvert.DeserializeObject<>
            return response;
        }
    }
}
