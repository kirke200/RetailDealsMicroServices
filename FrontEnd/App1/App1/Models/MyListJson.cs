using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App1.Models
{
    public class MyListJson
    {
        public string Id { get; set; }
        [JsonProperty("Name")]
        public string Topic { get; set; }
        public float Price { get; set; }
        [JsonProperty("NumberOfItems")]
        public int itemCount { get; set; }
    }
}
