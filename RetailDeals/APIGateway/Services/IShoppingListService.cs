using APIGateway.Models;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Services
{
    public interface IShoppingListService
    {
        [AllowAnyStatusCode]
        [Get("api/shoppingList/list")]
        public Task<GetShoppingListsResponse> Get([Query] string userId);
    }
}
