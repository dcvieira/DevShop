using System;
namespace Basket.API.Models
{
    public class UpdateBasketItemQuantity
    {
        public Guid CatalogItemId { get; set; }

        public int newQuantity { get; set; }

    }
}
