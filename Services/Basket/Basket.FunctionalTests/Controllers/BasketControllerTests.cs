using System;
using System.Net.Http;
using System.Threading.Tasks;
using Basket.API;
using Xunit;

namespace Basket.FunctionalTests.Controllers
{
    public class BasketControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        private readonly CustomWebApplicationFactory<Startup> _factory;

        public BasketControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            factory.ClientOptions.BaseAddress = new Uri("https://localhost:5002/api/v1/basket");

            _client = factory.CreateClient();
            _factory = factory;
        }

        [Fact]
        public async Task GetBasketAsync_ReturnsSuccess()
        {
            var response = await _client.GetAsync("");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GetBasketAsync_ReturnsSuccess2()
        {
            var response = await _client.GetAsync("");

            response.EnsureSuccessStatusCode();
        }
    }
}
