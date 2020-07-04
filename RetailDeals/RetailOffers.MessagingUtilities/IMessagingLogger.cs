using System;
using System.Collections.Generic;
using System.Text;

namespace RetailOffers.MessagingUtilities
{
    public interface IMessagingLogger
    {
        void Error(string v);
        void Info(string v);
    }
}
