using MongoDB.Driver;
using RetailItemUpdater.Domain.DAL.Models;
using RetailItemUpdater.Domian.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL
{
    public class MongoDbContext
    {
        public IMongoCollection<RetailGroup> RetailGroups { get; set; }
        public MongoDbContext(IRetailDealsDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.DatabaseName);

            RetailGroups = db.GetCollection<RetailGroup>(settings.RetailGroupsCollectionName);
        }
    }
}
