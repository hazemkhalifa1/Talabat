namespace Talabat.APIs.DTOs
{
    public class CustomerBasketDto
    {

        public string Id { get; set; }

        public CustomerBasketDto(string id)
        {
            Id = id;
        }

        public List<BasketItemDto> BasketItems { get; set; }
        public string? PaymentIntentId { get; set; }
        public string? ClientSecret { get; set; }
        public int? DeliveryMethodId { get; set; }
    }
}
