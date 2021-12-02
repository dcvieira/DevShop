using System;
using System.Threading.Tasks;

namespace Basket.API.Services
{
    public interface ICatalogService
    {
        Task<Models.CatalogItem> GetCatalogItem(Guid id);
    }
}
