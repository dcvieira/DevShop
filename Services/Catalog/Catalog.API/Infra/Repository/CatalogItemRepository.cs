using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infra.Repository
{
    public class CatalogItemRepository : ICatalogItemRepository
    {
        private readonly CatalogContext _context;

        public CatalogItemRepository(CatalogContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItems()
        {
            return await _context.CatalogItems.Include(c => c.Category).ToListAsync();
        }

    }
}
