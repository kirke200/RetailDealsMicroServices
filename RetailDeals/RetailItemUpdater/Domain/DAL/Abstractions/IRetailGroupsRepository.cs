using RetailItemUpdater.Domian.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.Abstractions
{
    public interface IRetailGroupsRepository
    {
        Task<List<RetailGroup>> GetAllRetailGroupsAsync();
        Task<RetailGroup> GetRetailGroupFromNameAsync(string name);
        Task<RetailGroup> GetRetailGroupAsync(string id);
        Task UpdateRetailGroupsAsync(List<RetailGroup> retailGroups);
        Task UpdateOrCreateRetailGroupsAsync(List<RetailGroup> retailGroups);
        Task CreateRetailGroupsIfNotExistsAsync(List<RetailGroup> retailGroups);
    }
}
