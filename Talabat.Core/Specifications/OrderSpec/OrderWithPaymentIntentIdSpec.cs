using Talabat.Core.Entities.Order;

namespace Talabat.Core.Specifications.OrderSpec
{
    public class OrderWithPaymentIntentIdSpec : BaseSpecification<Order>
    {
        public OrderWithPaymentIntentIdSpec(string PaymentIntentId) : base(o => o.PaymentIntentId == PaymentIntentId)
        {

        }
    }
}
