using RetailItemUpdater.Domain.Adapters.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.Adapters.Abstractions.CoopApi
{
    public interface ICoopStoreApi
    {
        public Task<RetailGroupsDTO> GetAllRetailGroups();
    }
}
