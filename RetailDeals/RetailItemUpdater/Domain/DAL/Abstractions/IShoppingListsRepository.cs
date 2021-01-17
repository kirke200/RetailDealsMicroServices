using RetailItemUpdater.Domain.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.Abstractions
{
    public interface IShoppingListsRepository
    {
        Task<IEnumerable<ShoppingList>> GetShoppingListsFromUserId(string id);
    }
}
