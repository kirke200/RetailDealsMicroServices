using Newtonsoft;
using Newtonsoft.Json;

namespace RetailOffers.MessagingUtilities
{
    public class Event
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}