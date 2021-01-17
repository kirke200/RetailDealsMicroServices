using RetailItemUpdater.DTO;
using RetailOffers.MessagingUtilities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Queries
{
    public class GetShoppingLists : IQuery<ShoppingListsDTO>
    {
        public string UserId { get; set; }
    }
}
