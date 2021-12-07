using System;
using System.Threading.Tasks;
using Basket.API.Domain;
using Basket.API.Models;
using Basket.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("api/v1/basket")]
    public class BasketController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        private readonly IBasketRepository _basketRepository;

        public BasketController(ICatalogService catalogService, IBasketRepository basketRepository)
        {
            _catalogService = catalogService;
            _basketRepository = basketRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBasketAsync()
        {
            // Get User Basket
            var basketDomain = await _basketRepository.GetBasketById(UserFakeService.GetUser());

            // Get Basket Model
            var basketModel = basketDomain.GetBasket();

            return Ok(basketModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddBasketItemAsync([FromBody] AddBasketItemRequest request)
        {
            if (request == null || request.Quantity <= 0)
            {
                return BadRequest("Invalid payload");
            }

            // Get item from catalog
            var catalogItem = await _catalogService.GetCatalogItem(request.CatalogItemId);

            // Get current Basket status
            var basket = await _basketRepository.GetBasketById(UserFakeService.GetUser());

            // Add item to basket
            basket.AddBasketItem(catalogItem.Id, catalogItem.Name, catalogItem.Price, request.Quantity, catalogItem.ImgUrl);

            // Step 4 Save Basket in Cache
            await _basketRepository.SaveBasket(basket);

            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateBasketItemQuantityAsync([FromBody] UpdateBasketItemQuantity request)
        {
            if (request == null || request.newQuantity <= 0)
            {
                return BadRequest("Invalid payload");
            }

            // Get item from catalog
            var catalogItem = await _catalogService.GetCatalogItem(request.CatalogItemId);

            // Get current Basket status
            var basket = await _basketRepository.GetBasketById(UserFakeService.GetUser());

            // Add item to basket
            basket.UpdateBasketItemQuantity(catalogItem.Id, request.newQuantity);

            // Step 4 Save Basket in Cache
            await _basketRepository.SaveBasket(basket);

            return Ok();

        }

        [HttpDelete]
        [Route("{basketItemId:guid}")]
        public async Task<ActionResult> RemoveBasketItemAsync(Guid basketItemId)
        {


            // Get current Basket status
            var basket = await _basketRepository.GetBasketById(UserFakeService.GetUser());

            // Add item to basket
            basket.RemoveBasketItem(basketItemId);

            // Step 4 Save Basket in Cache
            await _basketRepository.SaveBasket(basket);

            return Ok();

        }

        [HttpDelete]
        [Route("clear")]
        public async Task<ActionResult> ClearBasket(Guid basketItemId)
        {

            await _basketRepository.ClearBasket(UserFakeService.GetUser());

            return Ok();

        }
    }
}
