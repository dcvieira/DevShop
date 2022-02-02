using System;
using Basket.API.Domain;
using Xunit;

namespace Basket.UnitTests.Domain
{
    public class BasketDomainShould
    {

        [Fact]
        public void Add_basket_Item()
        {
            // Arrange
            var basket = new API.Domain.Basket();
            var basketDomain = new BasketDomain(basket);
            var productId = Guid.NewGuid();
            var productName = "test product";

            // Act
            basketDomain.AddBasketItem(productId, productName, 20, 1, "");

            // Assert
            Assert.Single(basketDomain.GetBasket().Items);
            Assert.Equal(productId, basketDomain.GetBasket().Items[0].ProductId);
            Assert.Equal(productName, basketDomain.GetBasket().Items[0].ProductName);

        }

        [Fact]
        public void Increment_basket_Item_quantity_when_product_exist()
        {
            // Arrange
            var basket = new API.Domain.Basket();
            var basketDomain = new BasketDomain(basket);
            var productId = Guid.NewGuid();
            var productName = "test product";
            basketDomain.AddBasketItem(productId, productName, 20, 1, "");

            // Act
            basketDomain.AddBasketItem(productId, productName, 20, 1, "");

            // Assert
            Assert.Single(basketDomain.GetBasket().Items);
            Assert.Equal(productId, basketDomain.GetBasket().Items[0].ProductId);
            Assert.Equal(2, basketDomain.GetBasket().Items[0].Quantity);

        }

        [Fact]
        public void Update_basket_item_quantity()
        {
            // Arrange
            var basket = new API.Domain.Basket();
            var basketDomain = new BasketDomain(basket);
            var productId = Guid.NewGuid();
            var productName = "test product";
            basketDomain.AddBasketItem(productId, productName, 20, 1, "");

            // Act
            basketDomain.UpdateBasketItemQuantity(productId, 3);

            // Assert
            Assert.Single(basketDomain.GetBasket().Items);
            Assert.Equal(productId, basketDomain.GetBasket().Items[0].ProductId);
            Assert.Equal(3, basketDomain.GetBasket().Items[0].Quantity);
        }

        [Fact]
        public void Remove_basket_item()
        {
            // Arrange
            var basket = new API.Domain.Basket();
            var basketDomain = new BasketDomain(basket);
            var productId = Guid.NewGuid();
            var productName = "test product";
            basketDomain.AddBasketItem(productId, productName, 20, 1, "");
            var basketItemId = basketDomain.GetBasket().Items[0].Id;

            // Act
            basketDomain.RemoveBasketItem(basketItemId);

            // Assert
            Assert.Empty(basketDomain.GetBasket().Items);
        }

        [Fact]
        public void Remove_basket_item_when_basket_is_empty()
        {
            // Arrange
            var basket = new API.Domain.Basket();
            var basketDomain = new BasketDomain(basket);
            var basketItemId = Guid.NewGuid();

            // Act
            basketDomain.RemoveBasketItem(basketItemId);

            // Assert
            Assert.Empty(basketDomain.GetBasket().Items);
        }

    }
}
