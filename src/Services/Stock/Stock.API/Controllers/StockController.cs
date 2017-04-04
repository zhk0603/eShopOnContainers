using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Stock.API.Models;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Stock.API.IntegrationEvents.Events;

namespace Stock.API.Controllers
{
    [Route("api/[controller]")]
    public class StockController : Controller
    {
        private readonly IEventBus _eventBus;

        public StockController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        // GET api/stock
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/stock/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/stock
        [HttpPost]
        public void Post([FromBody]OrderStock orderStock)
        {
            var evt = new OrderStockProvidedIntegrationEvent(orderStock.OrderId);
            _eventBus.Publish(evt);
        }

        // PUT api/stock/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/stock/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
