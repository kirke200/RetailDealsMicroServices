using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.DTO
{
    public class ShoppingListsDTO
    {
        public IEnumerable<ShoppingListDTO> ShoppingLists { get; set; }


        public class ShoppingListDTO
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int NumberOfItems { get; set; }
            public float price { get; set; }
        }
    }
}
