using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Models
{
    public class GetShoppingListsResponse
    {


        public List<ShoppingList> ShoppingLists { get; set; }


        public class ShoppingList
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int NumberOfItems { get; set; }
            public float price { get; set; }
        }
    }   
}
