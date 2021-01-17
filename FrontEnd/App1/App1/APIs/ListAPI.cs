using App1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.ConnectionControllers
{
    class ListAPI
    {

        HttpClient client;

        public ListAPI()
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

            client.BaseAddress = new Uri("http://192.168.0.241:5000/api/RetailGroups?name=Kvickly");

            string json = JsonConvert.SerializeObject(list);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


            HttpResponseMessage response = null;

            response = await client.PostAsync(client.BaseAddress, content);

            if (response.IsSuccessStatusCode)
            {

            }

            //var jsonString = response.Content.ReadAsStringAsync();
            //JsonConvert.DeserializeObject<>
            return response;
        }

        public async Task<HttpResponseMessage> GetLists()
        {

            client.BaseAddress = new Uri("http://192.168.0.241:5000/api/RetailGroups?name=Kvickly");
            var so = new List<MyList>();

            HttpResponseMessage response = null;

            response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                so = JsonConvert.DeserializeObject<List<MyList>>(content);
            }

            //var jsonString = response.Content.ReadAsStringAsync();
            //JsonConvert.DeserializeObject<>
            return response;
        }

        public async Task<HttpResponseMessage> PutList(MyList list, bool isNewItem = false)
        {
            client.BaseAddress = new Uri("http://192.168.0.241:5000/api/RetailGroups?name=Kvickly");

            string json = JsonConvert.SerializeObject(list);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");


            HttpResponseMessage response = null;

            response = await client.PutAsync(client.BaseAddress, content);

            if (response.IsSuccessStatusCode)
            {

            }
            return response;
        }

        public async Task<HttpResponseMessage> DeleteList(MyList list, bool isNewItem = false)
        {
            var id = 1; //TODO get a real id

            Uri uri = new Uri(string.Format("http://192.168.0.241:5000/api/RetailGroups?name=Kvickly", id));

            HttpResponseMessage response = null;

            response = await client.DeleteAsync(uri);

            if (response.IsSuccessStatusCode)
            {

            }
            return response;
        }
    }


}
