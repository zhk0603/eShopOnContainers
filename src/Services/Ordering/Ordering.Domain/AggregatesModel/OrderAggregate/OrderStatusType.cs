using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.OrderAggregate
{
    public class OrderStatusType : Enumeration
    {
        public static OrderStatusType Pending
        = new OrderStatusType(0, "Pending");
        public static OrderStatusType Processing
        = new OrderStatusType(1, "Processing");
        public static OrderStatusType Shipped
        = new OrderStatusType(2, "Shipped");
        public static OrderStatusType Delivered
        = new OrderStatusType(3, "Delivered");

        private OrderStatusType() { }
        private OrderStatusType(int value, string displayName) : base(value, displayName) { }

    }
}
