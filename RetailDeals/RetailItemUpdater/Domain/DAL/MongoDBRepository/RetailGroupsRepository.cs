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

        public async Task CreateRetailGroupsIfNotExistsAsync(List<RetailGroup> retailGroups)
        {
            foreach (var retailGroup in retailGroups)
            {
                var options = new ReplaceOptions();
                options.IsUpsert = true;
                var filter = Builders<RetailGroup>.Filter.Where(x => x.Name == retailGroup.Name);
                await _retailGroups.ReplaceOneAsync(filter, retailGroup, options);
            }
        }

        public Task<List<RetailGroup>> GetAllRetailGroupsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<RetailGroup> GetRetailGroupFromNameAsync(string name)
        {
            var filter = Builders<RetailGroup>.Filter.Where(x => x.Name == name);
            var retailGroup = await _retailGroups.FindAsync(filter);

            return retailGroup.ToList().FirstOrDefault();
        }

        public async Task<RetailGroup> GetRetailGroupAsync(string id)
        {
            var filter = Builders<RetailGroup>.Filter.Where(x => x.Id == id);
            var retailGroup = await _retailGroups.FindAsync(filter);
            return retailGroup.ToList().FirstOrDefault();
        }

        public Task UpdateOrCreateRetailGroupsAsync(List<RetailGroup> retailGroups)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRetailGroupsAsync(List<RetailGroup> retailGroups)
        {
            throw new NotImplementedException();
        }
    }
}
