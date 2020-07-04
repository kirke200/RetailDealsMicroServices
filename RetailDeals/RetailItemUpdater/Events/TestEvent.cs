using RetailOffers.MessagingUtilities;
using RetailOffers.MessagingUtilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Events
{
    [QueueName("testevent")]
    public class TestEvent : IEvent
    {
        public string TestString { get; set; }
    }
}
