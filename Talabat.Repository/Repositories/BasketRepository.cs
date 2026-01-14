using StackExchange.Redis;
using System.Text.Json;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.Repository.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase redis;

        public BasketRepository(IConnectionMultiplexer Redis)
        {
            redis = Redis.GetDatabase();
        }
        public Task<bool> DeleteBasketAsync(string Id)
        => redis.KeyDeleteAsync(Id);

        public async Task<CustomerBasket?> GetBasketByIdAsync(string Id)
        {
            var Basket = await redis.StringGetAsync(Id);
            return Basket.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(Basket);
        }

        public async Task<CustomerBasket?> UpdateOrAddBasketAsync(CustomerBasket basket)
        {
            var JsonBasket = JsonSerializer.Serialize(basket);
            var AddedBaskst = await redis.StringSetAsync(basket.Id, JsonBasket, TimeSpan.FromDays(1));
            return AddedBaskst ? await GetBasketByIdAsync(basket.Id) : null;
        }
    }
}