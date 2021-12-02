using System;
using System.Threading.Tasks;
using Basket.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BasketController : ControllerBase
    {
        public BasketController()
        {
        }

        [HttpPost]
        public async Task<ActionResult> AddBasketItemAsync([FromBody] AddBasketItemRequest request)
        {
            if (request == null || request.Quantity == 0)
            {
                return BadRequest("Invalid payload");
            }

        }
    }
}
