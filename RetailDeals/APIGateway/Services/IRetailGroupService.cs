using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIGateway.Models;
using APIGateway.Queries;
using RestEase;

namespace APIGateway.Services
{
    public interface IRetailGroupService
    {

        [AllowAnyStatusCode]
        [Get("api/retailGroups/{id}")]
        public Task<RetailGroup> Get([Path] string id);

        [AllowAnyStatusCode]
        [Get("api/retailGroups")]
        public Task<RetailGroup> Find([Query] string id, [Query] string name);
    }
}
