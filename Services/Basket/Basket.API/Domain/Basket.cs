using System;
using System.Collections.Generic;

namespace Basket.API.Domain
{
    public class Basket
    {
        public Guid BuyerId { get; set; }

        public List<BasketItem> Items { get; set; } = new();

        public Basket()
        {
        }

        public Basket(Guid buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
