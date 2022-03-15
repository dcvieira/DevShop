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
            var bytesArray = await _distributedCache.GetAsync(basketId.ToString());


            if (bytesArray?.Length > 0)
            {
                using var stream = new MemoryStream(bytesArray);
                var basketModel = await JsonSerializer.DeserializeAsync<BasketModel>(stream);
                return new BasketDomain(basketModel);

            }
            return new BasketDomain(new BasketModel(basketId));

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
            var asBytes = JsonSerializer.SerializeToUtf8Bytes(basket);

            int cacheDuration = int.Parse(Configuration["CacheDurationMinutes"]);

            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromMinutes(cacheDuration));

            await _distributedCache.SetAsync(basket.BuyerId.ToString(), asBytes, options);
        }

        #endregion
    }
}
