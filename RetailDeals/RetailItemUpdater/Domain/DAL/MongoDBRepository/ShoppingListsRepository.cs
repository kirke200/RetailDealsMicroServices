using MongoDB.Driver;
using RetailItemUpdater.Domain.DAL.Abstractions;
using RetailItemUpdater.Domain.DAL.Models;
using RetailItemUpdater.Domian.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.MongoDBRepository
{
    public class ShoppingListsRepository : IShoppingListsRepository
    {
        private readonly IMongoCollection<ShoppingList> _shoppingLists;

        public ShoppingListsRepository(MongoDbContext dbContext)
        {
            _shoppingLists = dbContext.ShoppingLists;
        }
        public async Task<IEnumerable<ShoppingList>> GetShoppingListsFromUserId(string id)
        {
            var filter = Builders<ShoppingList>.Filter.Where(x => x.UserId == id);
            var shoppingLists = await _shoppingLists.FindAsync(filter);
            return shoppingLists.ToEnumerable();
        }
    }
}
