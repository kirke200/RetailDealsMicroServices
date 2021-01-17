using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.Models
{
    public class RetailDealsDatabaseSettings : IRetailDealsDatabaseSettings
    {
        public string RetailGroupsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ShoppingListCollectionName { get; set; }
    }

    public interface IRetailDealsDatabaseSettings
    {
        string RetailGroupsCollectionName { get; set; }
        string ShoppingListCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
