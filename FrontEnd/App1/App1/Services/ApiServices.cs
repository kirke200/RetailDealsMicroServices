using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    class ApiServices
    {
        HttpClient client;

        public ApiServices()
        {
            client = new HttpClient();

        }



        public async Task<HttpResponseMessage> PostList(MyList list)
        {

            client.BaseAddress = new Uri("https://192.168.0.241:5000/api/RetailGroups?name=Kvickly");

            string json = JsonConvert.SerializeObject(list);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


            HttpResponseMessage response = null;
          
            response = await client.PostAsync(client.BaseAddress, content);           

            if (response.IsSuccessStatusCode)
            {
                
            }

            return response;
        }

    }
}
