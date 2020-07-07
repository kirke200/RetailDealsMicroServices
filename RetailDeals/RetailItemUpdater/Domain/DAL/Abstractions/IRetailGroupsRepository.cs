using RetailItemUpdater.Domian.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.Abstractions
{
    public interface IRetailGroupsRepository
    {
        List<RetailGroup> GetAllRetailGroups();
        RetailGroup GetRetailGroup(string name);
        RetailGroup GetRetailGroup(Guid id);
        void UpdateRetailGroups(List<RetailGroup> retailGroups);
        void UpdateOrCreateRetailGroups(List<RetailGroup> retailGroups);
        void CreateRetailGroupsIfNotExists(List<RetailGroup> retailGroups);
    }
}
