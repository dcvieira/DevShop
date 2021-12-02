using System;
using System.Net.Http;
using System.Threading.Tasks;
using Basket.API.Extensions;
using Basket.API.Models;

namespace Basket.API.Services
{
    public class CatalogService : ICatalogService
    {

        private readonly HttpClient client;

        public CatalogService(HttpClient client)
        {
            this.client = client;
        }


        public async Task<CatalogItem> GetCatalogItem(Guid id)
        {
            var response = await client.GetAsync($"/api/events/{id}");
            return await response.ReadContentAs<Models.CatalogItem>();
        }
    }
}
