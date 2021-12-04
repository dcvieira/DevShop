using System;
using System.Threading.Tasks;

namespace Basket.API.Domain
{
    public interface IBasketRepository
    {
        Task<bool> BasketExists(Guid basketId);

        Task<BasketDomain> GetBasketById(Guid basketId);

        Task SaveBasket(BasketDomain basket);

        Task ClearBasket(Guid basketId);
    }
}
