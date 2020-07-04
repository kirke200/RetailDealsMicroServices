using RetailItemUpdater.Domain.Adapters.Abstractions.CoopApi;
using RetailItemUpdater.Domain.Services.Abstractions;
using RetailOffers.MessagingUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Events.Receivers
{
    public class UpdateRetailGroupsRequestedReceiver : IEventReceiver<UpdateRetailGroupsRequested>
    {
        private readonly IRetailGroupsUpdater _retailGroupsUpdater;

        public UpdateRetailGroupsRequestedReceiver(IRetailGroupsUpdater retailGroupsUpdater) {
            _retailGroupsUpdater = retailGroupsUpdater;
        }

        public async Task ReceiveEvent(UpdateRetailGroupsRequested eventToReceive)
        {
            await _retailGroupsUpdater.UpdateAllGroups();

        }
    }
}
