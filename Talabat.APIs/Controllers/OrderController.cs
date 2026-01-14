using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Core.Entities.Order;
using Talabat.Core.Services;

namespace Talabat.APIs.Controllers
{
    public class OrderController : APIBaseController
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(OrderToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<OrderToReturnDto>> CreateOrder(OrderDto model)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var CreatedOrder = await _orderService.CreateOrder(email, model.BasketId, model.DeliveryMethodId, model.ShippingAddress);
            if (CreatedOrder is null) return BadRequest(new ApiResponse(400));
            var MappedOrder = _mapper.Map<OrderToReturnDto>(CreatedOrder);
            return Ok(MappedOrder);
        }

        [ProducesResponseType(typeof(IReadOnlyList<OrderToReturnDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IReadOnlyList<OrderToReturnDto>>> GetOrdersForSpecificUser()
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var ReturnedOrder = await _orderService.GetOrdersForSpecificUser(email);
            if (ReturnedOrder is null || ReturnedOrder.Count <= 0) return NotFound(new ApiResponse(404));
            var MappedOrder = _mapper.Map<IReadOnlyList<OrderToReturnDto>>(ReturnedOrder);
            return Ok(MappedOrder);
        }

        [ProducesResponseType(typeof(OrderToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("{OrderId}")]
        [Authorize]
        public async Task<ActionResult<OrderToReturnDto>> GetSpecificOrdersForSpecificUser(int OrderId)
        {
            var email = User.FindFirstValue(ClaimTypes.Email);
            var ReturnedOrder = await _orderService.GetOrderByIdForSpecificUser(email, OrderId);
            if (ReturnedOrder is null) return NotFound(new ApiResponse(404));
            var MappedOrder = _mapper.Map<OrderToReturnDto>(ReturnedOrder);
            return Ok(MappedOrder);
        }

        [ProducesResponseType(typeof(IReadOnlyList<DeliveryMethod>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        [HttpGet("DeliveryMethods")]
        public async Task<ActionResult<OrderToReturnDto>> GetDeliveryMethods()
        {
            var deliveryMethods = await _orderService.GetDeliveryMethods();
            if (deliveryMethods is null || deliveryMethods.Count <= 0) return NotFound(new ApiResponse(404));
            return Ok(deliveryMethods);
        }
    }
}
