using TechTalk.SpecFlow;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork.Events;
namespace Shopping.Domain.SpecFlowTests
{

    [Binding]
    public class ProcessOrderSteps
    {
        private Order _order;

        public ProcessOrderSteps()
        {
            _order = new Order(Guid.NewGuid(), Guid.NewGuid(), new Address("", "", "", "", ""));
        }

        [Given(@"An order with (.*) units of a given product \(id (.*)\)")]
        public void GivenAnOrderWithUnitsOfAGivenProductId(int units, Guid productId)
        {
            _order.AddOrderItem(productId, "", 100, 0, "", units);
        }

        [When(@"I process the order")]
        public void WhenIProcessTheOrder()
        {
            _order.ProcessOrder();
        }

        [Then(@"a processing event should be emited indicating that (.*) units of product \(id (.*)\) are being processed")]
        public void ThenAProcessingEventShouldBeEmitedIndicatingThatUnitsOfProductIdAreBeingProcessed(int units, Guid productId)
        {
            Assert.AreEqual(1,_order.Events.Count);
            foreach (var e in _order.Events)
            {
                Assert.IsInstanceOfType( e,typeof(OrderProcessing));
            }
            Assert.AreEqual(_order.OrderStatus, OrderStatusType.Processing);
        }
    }
}
