using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.Services.Abstractions
{
    public interface IRetailGroupsUpdater
    {
        public Task UpdateAllGroups();

    }
}
