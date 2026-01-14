using Talabat.Core.Entities.Order;

namespace Talabat.Core.Specifications.OrderSpec
{
    public class OrderSpecification : BaseSpecification<Order>
    {
        public OrderSpecification(int id, string? BuyerEmail) : base(O =>
                                                (id > 0 || O.Id == id)
                                             && (!String.IsNullOrEmpty(BuyerEmail) || O.BuyerEmail == BuyerEmail))
        {
            Includes.Add(o => o.DeliveryMethod);
            Includes.Add(o => o.Items);
            OrderByDesc = o => o.OrderDate;
        }
    }
}
