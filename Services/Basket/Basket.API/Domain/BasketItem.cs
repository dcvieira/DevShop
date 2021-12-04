using System;

namespace Basket.API.Domain
{
    public class BasketItem
    {

        public BasketItem(Guid productId, string productName, decimal unitPrice, int quantity, string imgUrl)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
            ImgUrl = imgUrl;
        }

        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ImgUrl { get; set; }
    }
}


