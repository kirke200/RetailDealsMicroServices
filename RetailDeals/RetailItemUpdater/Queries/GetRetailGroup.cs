using RetailItemUpdater.DTO;
using RetailOffers.MessagingUtilities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Queries
{
    public class GetRetailGroup : IQuery<RetailGroupDto>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
