using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Application.Models;
using Catalog.API.Entities;
using Catalog.API.Infra;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Queries
{
    public class CatalogQueries : ICatalogQueries
    {
        private readonly CatalogContext _context;

        public CatalogQueries(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryDto>> GetCatalogCategories()
        {
            return await _context.Categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                Name = c.Name
            }).ToArrayAsync();
        }

        public async Task<IEnumerable<CatalogItemDto>> GetCatalogItems()
        {
            return await _context.CatalogItems.Include(c => c.Category).Select(c => new CatalogItemDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description,
                Price = c.Price,
                ImgUrl = c.ImgUrl,
                CategoryId = c.Category.CategoryId,
                CategoryName = c.Category.Name,
            }).ToArrayAsync();
        }


        public async Task<CatalogItemDto> GetCatalogItemById(Guid id)
        {
            var catalogItem = await _context.CatalogItems.Include(c => c.Category).FirstOrDefaultAsync(c => c.Id == id);

            return new CatalogItemDto
            {
                Id = catalogItem.Id,
                Name = catalogItem.Name,
                Description = catalogItem.Description,
                Price = catalogItem.Price,
                ImgUrl = catalogItem.ImgUrl,
                CategoryId = catalogItem.Category.CategoryId,
                CategoryName = catalogItem.Category.Name
            };
        }

    }
}
