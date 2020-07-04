using System;
using System.Collections.Generic;
using System.Text;

namespace RetailOffers.MessagingUtilities
{
    public class MessagingLogger : IMessagingLogger
    {
        public void Error(string v)
        {
            Console.WriteLine("ERROR: " + v);
        }

        public void Info(string v)
        {
            Console.WriteLine("INFO: " + v);
        }
    }
}
