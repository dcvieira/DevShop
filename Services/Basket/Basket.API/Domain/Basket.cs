using System;
using System.Collections.Generic;

namespace Basket.API.Domain
{
    public class BasketModel
    {
        public Guid BuyerId { get; set; }

        public List<BasketItem> Items { get; set; } = new();

        public BasketModel()
        {
        }

        public BasketModel(Guid buyerId)
        {
            BuyerId = buyerId;
        }
    }
}
