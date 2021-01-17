using RetailItemUpdater.Domain.DAL.Abstractions;
using RetailItemUpdater.DTO;
using RetailItemUpdater.Queries;
using RetailOffers.MessagingUtilities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Handlers.ShoppingList
{
    public class GetShoppingListsHandler : IQueryHandler<GetShoppingLists, ShoppingListsDTO>
    {
        private readonly IShoppingListsRepository _shoppingListsRepository;

        public GetShoppingListsHandler(IShoppingListsRepository shoppingListsRepository)
        {
            _shoppingListsRepository = shoppingListsRepository;
        }
        public async Task<ShoppingListsDTO> HandleAsync(GetShoppingLists query)
        {
            var shoppingLists = await _shoppingListsRepository.GetShoppingListsFromUserId(query.UserId);

            return new ShoppingListsDTO
            {
                ShoppingLists = shoppingLists.ToList().Select(x => new ShoppingListsDTO.ShoppingListDTO
                {
                    Id = x.Id,
                    Name = x.Name,
                    price = x.Price,
                    NumberOfItems = x.NumberOfItems

                })
            };
        }
    }
}
