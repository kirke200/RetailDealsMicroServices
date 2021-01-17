using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.DAL.Models
{
    public class ShoppingList
    {
        public ShoppingList()
        {
            Id = ObjectId.GenerateNewId().ToString();
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int NumberOfItems { get; set; }

    }
}
