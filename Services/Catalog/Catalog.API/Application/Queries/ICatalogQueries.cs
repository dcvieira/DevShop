using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Application.Models;
using Catalog.API.Models;

namespace Catalog.API.Application.Queries
{
    public interface ICatalogQueries
    {
        Task<IEnumerable<CatalogItemDto>> GetCatalogItems();

        Task<IEnumerable<CategoryDto>> GetCatalogCategories();
    }
}
