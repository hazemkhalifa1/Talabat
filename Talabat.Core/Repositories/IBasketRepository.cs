using Talabat.Core.Entities;

namespace Talabat.Core.Repositories
{
    public interface IBasketRepository
    {
        public Task<bool> DeleteBasketAsync(string Id);
        public Task<CustomerBasket?> UpdateOrAddBasketAsync(CustomerBasket basket);
        public Task<CustomerBasket?> GetBasketByIdAsync(string Id);
    }
}
