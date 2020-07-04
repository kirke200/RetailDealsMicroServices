using System;
using System.Collections.Generic;
using System.Text;

namespace RetailOffers.MessagingUtilities.Attributes
{
    public class QueueNameAttribute : Attribute
    {
        public QueueNameAttribute(string name)
        {
            Name = name.ToLower();
        }

        public string Name { get; }
    }
}
