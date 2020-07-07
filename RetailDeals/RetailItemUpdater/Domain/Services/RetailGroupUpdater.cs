using RetailItemUpdater.Domain.Adapters.Abstractions.CoopApi;
using RetailItemUpdater.Domain.DAL.Abstractions;
using RetailItemUpdater.Domain.Services.Abstractions;
using RetailItemUpdater.Domian.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.Services
{
    public class RetailGroupUpdater : IRetailGroupsUpdater
    {
        private readonly ICoopStoreApi _storeApi;
        private readonly IRetailGroupsRepository _retailGroupsRepository;

        public RetailGroupUpdater(ICoopStoreApi storeApi, IRetailGroupsRepository retailGroupsRepository)
        {
            _storeApi = storeApi;
            _retailGroupsRepository = retailGroupsRepository;
        }

        public async Task UpdateAllGroups()
        {
            Console.WriteLine("Updating retail groups");

            var retailGroupDTOs = await _storeApi.GetAllRetailGroups();

            var retialGroups = retailGroupDTOs.Data.Select(x => new RetailGroup
            {
                Name = x.Name
            }).ToList();

            _retailGroupsRepository.CreateRetailGroupsIfNotExists(retialGroups);

            Console.WriteLine("Retail groups updated");

        }
    }
}
