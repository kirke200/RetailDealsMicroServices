using MongoDB.Driver;
using RetailItemUpdater.Domain.DAL.Abstractions;
using RetailItemUpdater.Domian.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.MongoDBRepository
{
    public class RetailGroupsRepository : IRetailGroupsRepository
    {
        private readonly IMongoCollection<RetailGroup> _retailGroups;

        public RetailGroupsRepository(MongoDbContext dbContext)
        {
            _retailGroups = dbContext.RetailGroups;
        }

        public void CreateRetailGroupsIfNotExists(List<RetailGroup> retailGroups)
        {
            foreach (var retailGroup in retailGroups)
            {
                var options = new ReplaceOptions();
                options.IsUpsert = true;
                var filter = Builders<RetailGroup>.Filter.Where(x => x.Name == retailGroup.Name);
                _retailGroups.ReplaceOneAsync(filter, retailGroup, options);
            }
        }

        public List<RetailGroup> GetAllRetailGroups()
        {
            throw new NotImplementedException();
        }

        public RetailGroup GetRetailGroup(string name)
        {
            throw new NotImplementedException();
        }

        public RetailGroup GetRetailGroup(Guid id)
        {
            throw new NotImplementedException();
        }

        public void UpdateOrCreateRetailGroups(List<RetailGroup> retailGroups)
        {
            
        }

        public void UpdateRetailGroups(List<RetailGroup> retailGroups)
        {
            throw new NotImplementedException();
        }
    }
}
