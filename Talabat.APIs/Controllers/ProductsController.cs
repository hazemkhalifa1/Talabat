using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Talabat.APIs.DTOs;
using Talabat.APIs.Errors;
using Talabat.APIs.Helper;
using Talabat.Core;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.APIs.Controllers
{

    public class ProductsController : APIBaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDTO>>> GetAll([FromQuery] ProductSpecParams Params)
        {
            var Spec = new ProductWithTypeAndBrandSpec(Params);
            var Products = await _unitOfWork.Repository<Product>().GetAllWithSpecAsync(Spec);
            var MappedProducts = _mapper.Map<IReadOnlyList<ProductToReturnDTO>>(Products);
            var CountSpec = new ProductWithFiltrationForCount(Params);
            int Count = _unitOfWork.Repository<Product>().GetCountAsync(CountSpec);
            return Ok(new Pagination<ProductToReturnDTO>(Params.PageSize, Params.PageIndex, Count, MappedProducts));
        }

        [HttpGet("{Id}")]
        [ProducesResponseType(typeof(ProductToReturnDTO), 200)]
        [ProducesResponseType(typeof(ApiResponse), 404)]
        public async Task<ActionResult<ProductToReturnDTO>> GetProduct(int Id)
        {
            var Spec = new ProductWithTypeAndBrandSpec(Id);
            var Product = await _unitOfWork.Repository<Product>().GetEntityWithSpecAsync(Spec);
            if (Product is null)
                return NotFound(new ApiResponse(404));
            var MappedProduct = _mapper.Map<ProductToReturnDTO>(Product);
            return Ok(MappedProduct);
        }

        [HttpGet("Brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetAllBrands()
        => Ok(await _unitOfWork.Repository<ProductBrand>().GetAllAsync());

        [HttpGet("Types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetAllTypes()
        => Ok(await _unitOfWork.Repository<ProductType>().GetAllAsync());
    }
}
