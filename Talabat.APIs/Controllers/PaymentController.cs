using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Core.Services;

namespace Talabat.APIs.Controllers
{
    public class PaymentController : APIBaseController
    {
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;
        const string endpointSecret = "whsec_...";

        public PaymentController(IPaymentService paymentService,
            IMapper mapper)
        {
            _paymentService = paymentService;
            _mapper = mapper;
        }

        [Authorize]
        [ProducesResponseType(typeof(CustomerBasketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> CreateOrUpdatePaymentIntent(string basketId)
        {
            var Basket = await _paymentService.CreateOrUpdatePaymentIntent(basketId);
            if (Basket is null) return BadRequest(new ApiResponse(400));
            return Ok(_mapper.Map<CustomerBasketDto>(Basket));
        }

        [HttpPost("WebHook")]
        public async Task<IActionResult> StripeWebHook()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                var paymentIntent = stripeEvent.Data.Object as PaymentIntent;
                if (stripeEvent.Type == EventTypes.PaymentIntentSucceeded)
                {
                    await _paymentService.UpdatePaymentStatus(paymentIntent.Id, true);
                }
                else if (stripeEvent.Type == EventTypes.PaymentIntentPaymentFailed)
                {
                    await _paymentService.UpdatePaymentStatus(paymentIntent.Id, false);
                }
            }
            catch (StripeException e)
            {
                return BadRequest(new ApiResponse(400, e.Message));
            }
            return Ok();
        }
    }
}
