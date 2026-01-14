using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class ProductWithFiltrationForCount : BaseSpecification<Product>
    {
        public ProductWithFiltrationForCount(ProductSpecParams Params)
           : base(P =>
            (String.IsNullOrEmpty(Params.Search) || P.Name.ToLower().Contains(Params.Search))
            &&
            (!Params.BrandId.HasValue || P.ProductBrandId == Params.BrandId)
            &&
            (!Params.TypeId.HasValue || P.ProductTypeId == Params.TypeId))
        {

        }
    }
}
