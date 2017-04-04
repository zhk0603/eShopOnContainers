using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.API.IntegrationEvents.Events
{
    public class OrderPaidIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; private set; }

        public OrderPaidIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
