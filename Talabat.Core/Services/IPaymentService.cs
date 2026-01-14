using Talabat.Core.Entities;
using Talabat.Core.Entities.Order;

namespace Talabat.Core.Services
{
    public interface IPaymentService
    {
        Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string BasketId);
        Task<Order?> UpdatePaymentStatus(string PaymentIntentId, bool flag);
    }
}
