using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Domain.Adapters.DTOs
{
    public class RetailGroupsDTO
    {
        public List<GroupsDTO> Data { get; set; }
        public bool ApiObsolete { get; set; }
        public string ApiVersion { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }

    public class GroupsDTO
    {
        public string Name { get; set; }
    }
}
