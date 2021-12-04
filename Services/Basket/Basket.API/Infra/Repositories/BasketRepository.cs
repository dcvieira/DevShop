using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Basket.API.Domain;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Configuration;

namespace Basket.API.Infra.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _distributedCache;
        public IConfiguration Configuration { get; }

        public BasketRepository(IDistributedCache distributedCache, IConfiguration configuration)
        {
            _distributedCache = distributedCache;
            Configuration = configuration;
        }

        #region Basket Functions
        public async Task<BasketDomain> GetBasketById(Guid basketId)
        {
            var asString = await _distributedCache.GetStringAsync(basketId.ToString());
            if (string.IsNullOrEmpty(asString))
            {
                return new BasketDomain(new Domain.Basket(basketId));

            }

            else
            {
                var basketModel = JsonSerializer.Deserialize<Domain.Basket>(asString);
                return new BasketDomain(basketModel);
            }

        }

        public async Task<bool> BasketExists(Guid basketId)
        {
            var basket = await _distributedCache.GetAsync(basketId.ToString());
            return basket != null;
        }


        public async Task ClearBasket(Guid basketId)
        {
            await _distributedCache.RemoveAsync(basketId.ToString());
        }

        public async Task SaveBasket(BasketDomain basketDomain)
        {
            var basket = basketDomain.GetBasket();
            var asString = JsonSerializer.Serialize(basket);

            int cacheDuration = int.Parse(Configuration["CacheDurationMinutes"]);

            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(cacheDuration));

            await _distributedCache.SetStringAsync(basket.BuyerId.ToString(), asString, options);
        }

        #endregion
    }
}
