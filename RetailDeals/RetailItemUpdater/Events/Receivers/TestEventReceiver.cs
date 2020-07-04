using RetailOffers.MessagingUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Events.Receivers
{
    public class TestEventReceiver : IEventReceiver<TestEvent>
    {
        public async Task ReceiveEvent(TestEvent eventToReceive)
        {
            Console.WriteLine($"Received event {eventToReceive.TestString}");
        }
    }
}
