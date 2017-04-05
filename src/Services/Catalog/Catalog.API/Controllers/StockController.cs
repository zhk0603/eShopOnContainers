using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.eShopOnContainers.Services.Catalog.API.Infrastructure;
using Microsoft.Extensions.Options;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using System.Data.Common;
using Microsoft.eShopOnContainers.BuildingBlocks.IntegrationEventLogEF.Services;
using Microsoft.eShopOnContainers.Services.Catalog.API;
using Microsoft.EntityFrameworkCore;
using Catalog.API.Application.Commands;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Catalog.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class StockController : ControllerBase
    {
        private readonly CatalogContext _catalogContext;
        private readonly IOptionsSnapshot<Settings> _settings;
        private readonly IEventBus _eventBus;
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;

        public StockController(CatalogContext Context, IOptionsSnapshot<Settings> settings, IEventBus eventBus, Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory)
        {
            _catalogContext = Context;
            _settings = settings;
            _eventBus = eventBus;
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory;

            ((DbContext)Context).ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //POST api/v1/[controller]/
        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody]CreateStockCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        {
            bool result = false;
            if (Guid.TryParse(requestId, out Guid guid) && guid != Guid.Empty)
            {
                var requestCreateOrder = new IdentifiedCommand<CreateOrderCommand, bool>(command, guid);
                result = await _mediator.SendAsync(requestCreateOrder);
            }
            else
            {
                // If no x-requestid header is found we process the order anyway. This is just temporary to not break existing clients
                // that aren't still updated. When all clients were updated this could be removed.
                result = await _mediator.SendAsync(command);
            }

            if (result)
            {
                return Ok();
            }

            return BadRequest();
        }

        //PUT api/v1/[controller]/product/1/quantity/3
        [Route("product/{productId}/quantity/{quantity}")]
        [HttpPut]
        public async Task<IActionResult> UpdateStock(int productId, int quantity)
        {
            var productToUpdate = _catalogContext.CatalogItems.SingleOrDefault();
            productToUpdate.AddStock(quantity);
            await _catalogContext.SaveChangesAsync();

            return Ok();
        }        
        
    }
}
