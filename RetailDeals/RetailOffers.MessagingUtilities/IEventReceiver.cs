using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RetailOffers.MessagingUtilities
{
    public interface IEventReceiver<TEvent> where TEvent : IEvent
    {
        Task ReceiveEvent(TEvent eventToReceive);
    }
}
