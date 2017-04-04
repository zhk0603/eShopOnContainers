using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Payment.API.Model;
using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Abstractions;
using Payment.API.IntegrationEvents.Events;

namespace Payment.API.Controllers
{
    [Route("api/[controller]")]
    public class PaymentController : Controller
    {
        private readonly IEventBus _eventBus;

        public PaymentController(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
    
        // GET api/payment
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/payment/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/payment
        [HttpPost]
        public void Post([FromBody]OrderPayment orderPayment)
        {
            var evt = new OrderPaidIntegrationEvent(orderPayment.OrderId);
            _eventBus.Publish(evt);
        }

        // PUT api/payment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/payment/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
