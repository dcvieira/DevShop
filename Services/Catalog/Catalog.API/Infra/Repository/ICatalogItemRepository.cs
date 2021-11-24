using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Entities;

namespace Catalog.API.Infra.Repository
{
    public interface ICatalogItemRepository
    {
        Task<IEnumerable<CatalogItem>> GetCatalogItems();
    }
}
