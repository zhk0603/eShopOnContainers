using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class OrderStatusType : Enumeration
    {
        public static OrderStatusType Created
        = new OrderStatusType(0, "Created");
        public static OrderStatusType CheckedOut
        = new OrderStatusType(1, "CheckedOut");

        private OrderStatusType() { }
        private OrderStatusType(int value, string displayName) : base(value, displayName) { }

    }
}
