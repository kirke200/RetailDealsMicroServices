using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RetailItemUpdater.DTO;
using RetailItemUpdater.Queries;
using RetailOffers.MessagingUtilities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static RetailItemUpdater.DTO.ShoppingListsDTO;

namespace RetailItemUpdater.Controllers.Internal
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IQueryHandler<GetShoppingLists, ShoppingListsDTO> _getShoppingListsHandler;

        public ShoppingListController(IQueryHandler<GetShoppingLists, ShoppingListsDTO> getShoppingListsHandler)
        {
            _getShoppingListsHandler = getShoppingListsHandler;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ShoppingListsDTO>> Get([FromQuery] GetShoppingLists query)
        {
            var shoppingLists = await _getShoppingListsHandler.HandleAsync(query);

            if (shoppingLists == null) return NotFound();


            return shoppingLists;
        }


    }
}
