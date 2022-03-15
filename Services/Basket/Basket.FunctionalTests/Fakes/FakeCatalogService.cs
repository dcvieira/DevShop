using System;
using System.Threading.Tasks;
using Basket.API.Models;
using Basket.API.Services;

namespace Basket.FunctionalTests.Fakes
{
    public class FakeCatalogService : ICatalogService
    {
        public Task<CatalogItem> GetCatalogItem(Guid id)
        {
            return Task.FromResult(new CatalogItem
            {
                Id = id,
                Name = "Test Item",
                ImgUrl = "Test Image",
                Price = 100
            });
        }
    }
}
