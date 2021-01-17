using APIGateway.Models;
using APIGateway.Models.Queries;
using APIGateway.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Controllers.ShoppingList
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;

        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }

        [HttpGet("list")]
        public async Task<ActionResult<GetShoppingListsResponse>> Get([FromQuery] GetShoppingLists query)
        {
            var shoppingLists = await _shoppingListService.Get(query.UserId);

            return shoppingLists;
        }
    }
}
