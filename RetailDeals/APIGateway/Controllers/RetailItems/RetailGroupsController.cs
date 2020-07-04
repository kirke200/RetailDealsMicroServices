using APIGateway.Events;
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
        private RabbitMqSender _eventSender;

        public RetailGroupsController()
        {
            var _messageLogger = new MessagingLogger();
            _eventSender = new RabbitMqSender(_messageLogger);
        }

        [HttpPost("syncAllGroups")]
        public void SyncAllGroups()
        {
            var eventToPublish = new UpdateRetailGroupsRequested
            {
                Id = Guid.NewGuid()
            };

            _eventSender.PublishEvent(eventToPublish);
        }
    }
}
