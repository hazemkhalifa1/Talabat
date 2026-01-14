namespace Talabat.Core.Entities
{
    public class CustomerBasket
    {
        public string Id { get; set; }
        public List<BasketItem> BasketItems { get; set; }

        public string PaymentIntentId { get; set; }
        public string ClientSecret { get; set; }
        public int? DeliveryMethodId { get; set; }

        public CustomerBasket(string Id)
        {
            this.Id = Id;
        }
    }
}
