using System;
namespace Basket.API.Models
{
    public class AddBasketItemRequest
    {
        public Guid CatalogItemId { get; set; }

        public int Quantity { get; set; }

        public AddBasketItemRequest()
        {
            Quantity = 1;
        }
    }
}
