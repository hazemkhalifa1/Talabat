using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order;
using Talabat.Core.Repositories;
using Talabat.Core.Services;
using Talabat.Core.Specifications.OrderSpec;

namespace Talabat.Serivce
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBasketRepository _basketRepository;
        private readonly IPaymentService _paymentService;

        public OrderService(IUnitOfWork UnitOfWork,
            IBasketRepository BasketRepository,
            IPaymentService paymentService)
        {
            _unitOfWork = UnitOfWork;
            _basketRepository = BasketRepository;
            _paymentService = paymentService;
        }
        public async Task<Order?> CreateOrder(string BuyerEmail, string BasketId, int DeliveryMethodId, Address ShippingAddress)
        {
            var Basket = await _basketRepository.GetBasketByIdAsync(BasketId);
            var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(DeliveryMethodId);
            var orderItems = new List<OrderItem>();
            decimal subTotal = 0;
            if (Basket.BasketItems.Count > 0)
                foreach (var Item in Basket.BasketItems)
                {
                    var product = await _unitOfWork.Repository<Product>().GetByIdAsync(Item.Id);
                    var productItemOrder = new ProductItemOrdered(product.Id, product.Name, product.PictureUrl);
                    var orderItem = new OrderItem(productItemOrder, product.Price, Item.Count);
                    subTotal += (product.Price * Item.Count);
                    orderItems.Add(orderItem);
                }

            var orderSpec = new OrderWithPaymentIntentIdSpec(Basket.PaymentIntentId);
            var ExOrder = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(orderSpec);
            if (ExOrder is not null)
            {
                _unitOfWork.Repository<Order>().Delete(ExOrder);
                Basket = await _paymentService.CreateOrUpdatePaymentIntent(BasketId);
            }
            if (Basket is null) return null;
            var order = new Order(BuyerEmail, ShippingAddress, deliveryMethod, orderItems, subTotal, Basket.PaymentIntentId);
            await _unitOfWork.Repository<Order>().AddAsync(order);
            var result = await _unitOfWork.Complete();
            if (result <= 0) return null;
            return order;
        }


        public async Task<Order?> GetOrderByIdForSpecificUser(string BuyerEmail, int OrderId)
        {
            var orderSpec = new OrderSpecification(OrderId, BuyerEmail);
            var order = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(orderSpec);
            return order;
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForSpecificUser(string BuyerEmail)
        {
            var orderSpec = new OrderSpecification(0, BuyerEmail);
            var orders = await _unitOfWork.Repository<Order>().GetAllWithSpecAsync(orderSpec);
            return orders;
        }
        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethods()
        {
            var DeliveryMethods = await _unitOfWork.Repository<DeliveryMethod>().GetAllAsync();
            return DeliveryMethods;
        }
    }
}
