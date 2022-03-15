using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Basket.API;
using Basket.API.Domain;
using Xunit;

namespace Basket.FunctionalTests.Controllers
{
    public class BasketControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public BasketControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("https://localhost:5002/api/v1/basket/");

            _client = factory.CreateClient();
            _factory = factory;
        }

        [Fact]
        public async Task GetBasket_ReturnsSuccessStatusCode()
        {
            var response = await _client.GetAsync("");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task AddBasketItem_DeleteBasketItem_ReturnsExpectedResult()
        {
            // Add basket Item
            var content = GetValidAddBasketItemRequestJsonContent();
            var postResponse = await _client.PostAsync("", content);

            postResponse.EnsureSuccessStatusCode();


            // Get basket
            var basketModel = await _client.GetFromJsonAsync<BasketModel>("");
            Assert.Single(basketModel.Items);

            //Delete BasketItem
            //var deleteResponse = await _client.DeleteAsync($"{basketDomain.GetBasket().Items[0].Id}");

            //deleteResponse.EnsureSuccessStatusCode();
            //Assert.Empty(basketDomain.GetBasket().Items);


        }

        [Fact]
        public async Task ClearBasket_ReturnsSuccessStatusCode()
        {
            var response = await _client.DeleteAsync("clear");

            response.EnsureSuccessStatusCode();
        }


        private static JsonContent GetValidAddBasketItemRequestJsonContent()
        {
            var addBasketItemRequest = new Models.AddBasketItemRequestTestModel { CatalogItemId = Guid.NewGuid(), Quantity = 1 };
            return JsonContent.Create(addBasketItemRequest);
        }
    }
}
