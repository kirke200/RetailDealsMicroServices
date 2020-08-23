using APIGateway.Events;
using APIGateway.Models;
using APIGateway.Queries;
using APIGateway.Services;
using Microsoft.AspNetCore.Mvc;
using RetailOffers.MessagingUtilities;
using RetailOffers.MessagingUtilities.RabbitMq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGateway.Controllers.RetailItems
{
    [ApiController]
    [Route("api/[controller]")]
    public class RetailGroupsController : ControllerBase
    {
        private readonly IRetailGroupService _retailGroupService;
        private RabbitMqSender _eventSender;

        public RetailGroupsController(IRetailGroupService retailGroupService)
        {
            var _messageLogger = new MessagingLogger();
            _eventSender = new RabbitMqSender(_messageLogger);
            _retailGroupService = retailGroupService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RetailGroup>> Get([FromRoute] string id)
        {
            var retailGroup = await _retailGroupService.Get(id);

            return retailGroup;
        }

        [HttpGet]
        public async Task<ActionResult<RetailGroup>> Get([FromQuery] GetRetailGroup query)
        {
            var retailGroup = await _retailGroupService.Find(query);

            return retailGroup;
        }

        [HttpPost("syncAllGroups")]
        public async Task<ActionResult> SyncAllGroups()
        {
            var eventToPublish = new UpdateRetailGroupsRequested
            {
                Id = Guid.NewGuid()
            };

            _eventSender.PublishEvent(eventToPublish);

            return Accepted();
        }
    }
}
