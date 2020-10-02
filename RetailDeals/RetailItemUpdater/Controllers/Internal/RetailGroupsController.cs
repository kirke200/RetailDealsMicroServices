using Microsoft.AspNetCore.Mvc;
using RetailItemUpdater.DTO;
using RetailItemUpdater.Queries;
using RetailOffers.MessagingUtilities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RetailItemUpdater.Controllers.Internal
{
    [ApiController]
    [Route("api/[controller]")]
    public class RetailGroupsController : ControllerBase
    {
        private readonly IQueryHandler<GetRetailGroup, RetailGroupDto> _getRetailGroupHandler;

        public RetailGroupsController(IQueryHandler<GetRetailGroup, RetailGroupDto> getRetailGroupHandler)
        {
            _getRetailGroupHandler = getRetailGroupHandler;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RetailGroupDto>> Get([FromRoute]string id)
        {
            Console.WriteLine("Received request");
            var retailGroupDto = await _getRetailGroupHandler.HandleAsync(new GetRetailGroup()
            {
                Id = id
            });

            if (retailGroupDto == null) return NotFound();

            return retailGroupDto;
        }

        [HttpGet]
        public async Task<ActionResult<RetailGroupDto>> Get([FromQuery] GetRetailGroup query)
        {
            Console.WriteLine("Received request");
            var retailGroupDto = await _getRetailGroupHandler.HandleAsync(query);

            if (retailGroupDto == null) return NotFound();

            return retailGroupDto;
        }

    }
}
