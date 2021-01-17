using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace App1.Services
{
    class ApiServices
    {
        HttpClient client;

        public ApiServices()
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



        public async Task<HttpResponseMessage> PostList(MyList list)
        {

            client.BaseAddress = new Uri(Config.ConnectionConfig.GetAPIBaseAdress());

            string json = JsonConvert.SerializeObject(list);
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

    }
}
