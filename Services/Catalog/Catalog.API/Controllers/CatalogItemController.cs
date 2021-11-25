using System;
using System.Threading.Tasks;
using Catalog.API.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/catalog")]
    [ApiController]
    public class CatalogItemController : ControllerBase
    {
        private readonly ICatalogItemQueries _catalogItemRepository;

        public CatalogItemController(ICatalogItemQueries catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _catalogItemRepository.GetCatalogItems();

            return Ok(items);
        }
    }
}
