using RetailItemUpdater.Domain.DAL.Abstractions;
using RetailItemUpdater.DTO;
using RetailItemUpdater.Queries;
using RetailOffers.MessagingUtilities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Handlers.RetailGroups
{
    public class GetRetailGroupHandler : IQueryHandler<GetRetailGroup, RetailGroupDto>
    {
        private readonly IRetailGroupsRepository _retailGroupsRepository;

        public GetRetailGroupHandler(IRetailGroupsRepository retailGroupsRepository)
        {
            _retailGroupsRepository = retailGroupsRepository;
        }

        public async Task<RetailGroupDto> HandleAsync(GetRetailGroup query)
        {
            var retailGroup = !string.IsNullOrEmpty(query.Id) ?  
                await _retailGroupsRepository.GetRetailGroupAsync(query.Id) 
                : 
                await _retailGroupsRepository.GetRetailGroupFromNameAsync(query.Name);

            if (retailGroup == null) return null;

            Console.WriteLine($"Retrieved retail group with name {retailGroup.Name}");

            return new RetailGroupDto
            {
                Name = retailGroup.Name
            };
        }
    }
}
