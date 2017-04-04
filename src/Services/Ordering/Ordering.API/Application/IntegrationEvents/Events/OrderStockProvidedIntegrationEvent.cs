using Microsoft.eShopOnContainers.BuildingBlocks.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.API.Application.IntegrationEvents.Events
{
    public class OrderStockProvidedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; private set; }

        public OrderStockProvidedIntegrationEvent(int orderId)
        {
            OrderId = orderId;
        }
    }
}
