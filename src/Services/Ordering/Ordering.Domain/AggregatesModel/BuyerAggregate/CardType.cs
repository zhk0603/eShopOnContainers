using Microsoft.eShopOnContainers.Services.Ordering.Domain.Seedwork;
using Microsoft.eShopOnContainers.Services.Ordering.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.eShopOnContainers.Services.Ordering.Domain.AggregatesModel.BuyerAggregate
{
    public class CardType : Enumeration
    {
        public static readonly CardType Visa
        = new CardType(0, "Visa");
        public static readonly CardType Amex
        = new CardType(1, "Amex");
        public static readonly CardType MasterCard
       = new CardType(2, "Master Card");

        private CardType() { }
        private CardType(int value, string displayName) : base(value, displayName)
        {
        }

    }
   

}
