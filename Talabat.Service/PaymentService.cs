using Microsoft.Extensions.Configuration;
using Stripe;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Order;
using Talabat.Core.Repositories;
using Talabat.Core.Services;
using Talabat.Core.Specifications.OrderSpec;
using Product = Talabat.Core.Entities.Product;

namespace Talabat.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IConfiguration _configuration;
        private readonly IBasketRepository _basketRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IConfiguration configuration,
            IBasketRepository basketRepository,
            IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _basketRepository = basketRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string BasketId)
        {
            StripeConfiguration.ApiKey = _configuration["StripeKeys:Secretkey"];

            var Basket = await _basketRepository.GetBasketByIdAsync(BasketId);

            if (Basket is null) return null;

            decimal ShippingPrice = 0;

            if (Basket.DeliveryMethodId.HasValue)
            {
                var deliveryMethod = await _unitOfWork.Repository<DeliveryMethod>().GetByIdAsync(Basket.DeliveryMethodId.Value);
                ShippingPrice = deliveryMethod.Cost;
            }

            if (Basket.BasketItems.Count > 0)

                foreach (var item in Basket.BasketItems)
                {
                    var product = await _unitOfWork.Repository<Product>().GetByIdAsync(item.Id);
                    if (item.Price != product.Price)
                        item.Price = product.Price;
                }

            var subTotal = Basket.BasketItems.Sum(i => i.Price * i.Count);

            var service = new PaymentIntentService();
            var paymentIntent = new PaymentIntent();
            if (String.IsNullOrEmpty(Basket.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions()
                {
                    Amount = (long)(ShippingPrice * 100 + subTotal * 100),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { "card" }
                };
                paymentIntent = await service.CreateAsync(options);
            }
            else
            {
                var options = new PaymentIntentUpdateOptions()
                {
                    Amount = (long)(ShippingPrice * 100 + subTotal * 100),

                };
                paymentIntent = await service.UpdateAsync(Basket.PaymentIntentId, options);
            }
            Basket.PaymentIntentId = paymentIntent.Id;
            Basket.ClientSecret = paymentIntent.ClientSecret;
            await _basketRepository.UpdateOrAddBasketAsync(Basket);
            return Basket;
        }

        public async Task<Order?> UpdatePaymentStatus(string PaymentIntentId, bool flag)
        {
            var spec = new OrderWithPaymentIntentIdSpec(PaymentIntentId);
            var order = await _unitOfWork.Repository<Order>().GetEntityWithSpecAsync(spec);

            if (flag)
                order.Status = OrderStatus.PaymentReceived;
            else
                order.Status = OrderStatus.PaymentFailed;
            _unitOfWork.Repository<Order>().Update(order);
            await _unitOfWork.Complete();
            return order;
        }
    }
}
