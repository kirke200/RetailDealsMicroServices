using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Queries;
using RestEase;

namespace APIGateway.Services
{
    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IRetailGroupService
    {

        [AllowAnyStatusCode]
        [Get("retailGroups/{id}")]
        public Task<RetailGroup> Get([Path] string id);

        [AllowAnyStatusCode]
        [Get("retailGroups")]
        public Task<RetailGroup> Find([Query] GetRetailGroup query);
    }
}
