using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Infra;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Queries
{
    public class CatalogItemQueries : ICatalogItemQueries
    {
        private readonly CatalogContext _context;

        public CatalogItemQueries(CatalogContext context)
        {
            _context = context;
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

    }
}
