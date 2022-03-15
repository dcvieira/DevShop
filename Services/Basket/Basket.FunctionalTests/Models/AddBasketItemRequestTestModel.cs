using System;
namespace Basket.FunctionalTests.Models
{
    public class AddBasketItemRequestTestModel
    {
        public Guid CatalogItemId { get; set; }

        public int Quantity { get; set; }
    }
}
