using Newtonsoft.Json;
using RetailOffers.MessagingUtilities;
using RetailOffers.MessagingUtilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Events
{
    [QueueName("UpdateRetailGroupsRequested")]
    public class UpdateRetailGroupsRequested : IEvent
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
