using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.Core.Entities;
using Talabat.Core.Repositories;

namespace Talabat.APIs.Controllers
{
    public class BasketController : APIBaseController
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IMapper _mapper;

        public BasketController(IBasketRepository BasketRepo,
                                IMapper mapper)
        {
            _basketRepo = BasketRepo;
            _mapper = mapper;
        }

        [HttpGet("{BasketId}")]
        public async Task<ActionResult<CustomerBasketDto>> GetOrRecreateBasket(string BasketId)
        {
            var basket = await _basketRepo.GetBasketByIdAsync(BasketId);
            return basket is null ? new CustomerBasketDto(BasketId) : _mapper.Map<CustomerBasketDto>(basket);
        }

        [ProducesResponseType(typeof(CustomerBasketDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<ActionResult<CustomerBasketDto>> UpdateOrCreateBasket(CustomerBasketDto basket)
        {
            var MappedBasket = _mapper.Map<CustomerBasket>(basket);
            var updatedBasket = await _basketRepo.UpdateOrAddBasketAsync(MappedBasket);
            return updatedBasket is null ? BadRequest(new ApiResponse(400)) : basket;
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeleteBasket(string BasketId)
        {
            return await _basketRepo.DeleteBasketAsync(BasketId);
        }
    }
}
