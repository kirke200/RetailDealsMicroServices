using System;
using System.Collections.Generic;
using System.Text;

namespace RetailOffers.MessagingUtilities
{
    public interface IEventSender
    {
        void PublishEvent<TEvent>(TEvent eventToPublish) where TEvent : IEvent;
    }
}
