using System;
using System.Linq;

namespace Basket.API.Domain
{
    public class BasketDomain
    {
        private readonly Basket _basket;

        public BasketDomain(Basket basket)
        {
            _basket = basket;
        }

        public Basket GetBasket()
        {
            return _basket;
        }

        public void AddBasketItem(Guid productId, string productName, decimal unitPrice, int quantity, string ImgUrl)

        {
            var existingItem = _basket.Items.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem == null)
            {
                // Add new item
                _basket.Items.Add(new BasketItem(productId, productName, unitPrice, quantity, ImgUrl));

            }
            else
            {
                // Update existing item
                existingItem.Quantity += quantity;
                existingItem.ProductName = productName;
                existingItem.UnitPrice = unitPrice;
                existingItem.ImgUrl = ImgUrl;
            }
        }

        public void UpdateBasketItemQuantity(Guid productId, int newQuantity)
        {
            var existingItem = _basket.Items.FirstOrDefault(item => item.ProductId == productId);

            if (existingItem != null)
            {
                existingItem.Quantity = newQuantity;
            }
        }

        public void RemoveBasketItem(Guid basketItemId)
        {
            var existingItem = _basket.Items.FirstOrDefault(item => item.Id == basketItemId);

            if (existingItem != null)
            {
                _basket.Items.Remove(existingItem);
            }
        }

    }
}

