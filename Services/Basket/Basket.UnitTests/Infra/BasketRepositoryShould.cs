using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Basket.API.Infra.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace Basket.UnitTests.Basket.Basket.UnitTests.Infra
{
    public class BasketRepositoryShould
    {
        private Mock<IDistributedCache> mockDistributedCache;
        private Mock<IConfiguration> mockIConfiguration;
        private BasketRepository sut;

        public BasketRepositoryShould()
        {
            mockDistributedCache = new Mock<IDistributedCache>();
            mockIConfiguration = new Mock<IConfiguration>();
            sut = new BasketRepository(mockDistributedCache.Object, mockIConfiguration.Object);
        }

        [Fact]
        public async Task Return_empty_basket()
        {
            var emptyByteArray = new byte[] { };
            mockDistributedCache.Setup(x => x.GetAsync(It.IsAny<string>(), It.IsAny<CancellationToken>())).ReturnsAsync(emptyByteArray);
            var basketId = Guid.NewGuid();

            var basketDomain = await sut.GetBasketById(basketId);

            Assert.Empty(basketDomain.GetBasket().Items);
        }


        [Fact]
        public async Task Return_basket()
        {
            var basketId = Guid.NewGuid();
            var basketModel = new API.Domain.Basket
            {
                BuyerId = basketId,
                Items = new List<API.Domain.BasketItem>
                {
                    new API.Domain.BasketItem(Guid.NewGuid(), "product 01", 10, 1, "image 01")
                }
            };


            var basketModelByteArray = JsonSerializer.SerializeToUtf8Bytes(basketModel);

            mockDistributedCache.Setup(x => x.GetAsync(basketId.ToString(), It.IsAny<CancellationToken>())).ReturnsAsync(basketModelByteArray);


            var basketDomain = await sut.GetBasketById(basketId);

            Assert.Single(basketDomain.GetBasket().Items);
            Assert.Equal(basketId, basketDomain.GetBasket().BuyerId);
        }
    }
}
