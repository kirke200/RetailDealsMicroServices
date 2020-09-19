using APIGateway.Events;
using Microsoft.AspNetCore.Mvc;
using RetailOffers.MessagingUtilities;
using RetailOffers.MessagingUtilities.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Controllers.Users
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IEventSender _eventSender;

        public UsersController(IEventSender eventSender)
        {
            _eventSender = eventSender;
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            Console.WriteLine("Getting user with id " + id);
            return "Getting user with id "+id;
        }

        [HttpPost("{name}")]
        public void Create(string name)
        {
            Console.WriteLine($"Created user with name {name}");
        }
        
        [HttpPost("sendEvent")]
        public void SendEvent()
        {
            var eventToSend = new TestEvent
            {
                TestString = "Sending event to RetailItemUpdater"
            };
            _eventSender.PublishEvent(eventToSend);
        }

    }
}
