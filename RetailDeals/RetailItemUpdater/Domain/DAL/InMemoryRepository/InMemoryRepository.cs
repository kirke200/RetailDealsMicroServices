using RetailItemUpdater.Domain.DAL.Abstractions;
using RetailItemUpdater.Domian.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.InMemoryRepository
{
    public class InMemoryRepository : IRetailGroupsRepository
    {
        private List<RetailGroup> _retailGroups = new List<RetailGroup>();

        public void CreateRetailGroupsIfNotExists(List<RetailGroup> retailGroups)
        {
            throw new NotImplementedException();
        }

        public Task CreateRetailGroupsIfNotExistsAsync(List<RetailGroup> retailGroups)
        {
            throw new NotImplementedException();
        }

        public List<RetailGroup> GetAllRetailGroups()
        {
            return _retailGroups;
        }

        public Task<List<RetailGroup>> GetAllRetailGroupsAsync()
        {
            return Task.FromResult(_retailGroups);
        }

        public Task<RetailGroup> GetRetailGroupAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<RetailGroup> GetRetailGroupFromNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateOrCreateRetailGroupsAsync(List<RetailGroup> retailGroups)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRetailGroupsAsync(List<RetailGroup> retailGroups)
        {
            _retailGroups = retailGroups;

            return Task.CompletedTask;
        }
    }
}
