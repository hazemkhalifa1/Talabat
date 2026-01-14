using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public class ProductWithTypeAndBrandSpec : BaseSpecification<Product>
    {
        public ProductWithTypeAndBrandSpec(ProductSpecParams Params)
            : base(P =>
            (String.IsNullOrEmpty(Params.Search) || P.Name.ToLower().Contains(Params.Search))
            &&
            (!Params.BrandId.HasValue || P.ProductBrandId == Params.BrandId)
            &&
            (!Params.TypeId.HasValue || P.ProductTypeId == Params.TypeId))
        {
            Includes.Add(p => p.ProductType);
            Includes.Add(p => p.ProductBrand);

            if (Params.Sort is not null)
                switch (Params.Sort)
                {
                    case "PriceAsc":
                        OrderBy = P => P.Price;
                        break;
                    case "PriceDesc":
                        OrderByDesc = P => P.Price;
                        break;
                    default:
                        OrderBy = P => P.Name;
                        break;
                }

            ApplyPagination(Params.PageSize * (Params.PageIndex - 1), Params.PageSize);
        }

        public ProductWithTypeAndBrandSpec(int Id) : base()
        {
            Includes.Add(p => p.ProductType);
            Includes.Add(p => p.ProductBrand);
        }
    }
}
