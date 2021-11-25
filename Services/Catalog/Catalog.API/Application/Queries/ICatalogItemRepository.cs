using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.API.Models;

namespace Catalog.API.Application.Queries
{
    public interface ICatalogItemQueries
    {
        Task<IEnumerable<CatalogItemDto>> GetCatalogItems();
    }
}
