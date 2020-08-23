using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Configuration
{
    public class RestEaseSettings
    {
        public const string RestEase = "RestEaseSettings";
        public string LoadBalancer { get; set; }
        public IEnumerable<Service> Services { get; set; }
    }

    public class Service
    {
        public string Name { get; set; }
        public string Host { get; set; }
        public string Scheme { get; set; }
        public string Port { get; set; }
    }
}
