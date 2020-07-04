using RetailItemUpdater.Domain.DAL.Abstractions;
using RetailItemUpdater.Domian.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.InMemoryRepository
{
    public class InMemoryRepository : IRetailGroupsRepository
    {
        private List<RetailGroup> _retailGroups = new List<RetailGroup>();
        public List<RetailGroup> GetAllRetailGroups()
        {
            return _retailGroups;
        }

        public RetailGroup GetRetailGroup(string name)
        {
            throw new NotImplementedException();
        }

        public RetailGroup GetRetailGroup(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateRetailGroups(List<RetailGroup> retailGroups)
        {
            _retailGroups = retailGroups;
        }
    }
}
