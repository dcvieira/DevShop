using System;
using System.Threading.Tasks;
using Catalog.API.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/v1/catalog")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogQueries _catalogItemRepository;

        public CatalogController(ICatalogQueries catalogItemRepository)
        {
            _catalogItemRepository = catalogItemRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var items = await _catalogItemRepository.GetCatalogItems();

            return Ok(items);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var catalogItem = await _catalogItemRepository.GetCatalogItemById(id);

            return Ok(catalogItem);
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var items = await _catalogItemRepository.GetCatalogCategories();

            return Ok(items);
        }
    }
}
