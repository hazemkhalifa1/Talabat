using Talabat.Core.Entities.Order;

namespace Talabat.Core.Services
{
    public interface IOrderService
    {
        public Task<Order?> CreateOrder(string BuyerEmail, string BasketId, int DeliveryMethodId, Address ShippingAddress);
        public Task<IReadOnlyList<Order>> GetOrdersForSpecificUser(string BuyerEmail);
        public Task<Order?> GetOrderByIdForSpecificUser(string BuyerEmail, int OrderId);
        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods();
    }
}
