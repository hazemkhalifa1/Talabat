using System.Text.Json;
using Talabat.Core.Entities.Order;

namespace Talabat.Repository.Data
{
    public static class TalabatContextSeeding
    {
        public static async Task DataSeedingAsync(TalabatContext context)
        {
            //if (!context.Set<ProductBrand>().Any())
            //{
            //    var BrandsData = await File.ReadAllTextAsync("../Talabat.Repository/Data/Seed/brands.json");
            //    var Brands = JsonSerializer.Deserialize<List<ProductBrand>>(BrandsData);
            //    if (Brands?.Count > 0)
            //        await context.Set<ProductBrand>().AddRangeAsync(Brands);
            //    await context.SaveChangesAsync();
            //}

            //if (!context.Set<ProductType>().Any())
            //{
            //    var TypesData = await File.ReadAllTextAsync("../Talabat.Repository/Data/Seed/types.json");
            //    var Types = JsonSerializer.Deserialize<List<ProductType>>(TypesData);
            //    if (Types?.Count > 0)
            //        await context.Set<ProductType>().AddRangeAsync(Types);
            //    await context.SaveChangesAsync();
            //}

            //if (!context.Set<Product>().Any())
            //{
            //    var ProductsData = await File.ReadAllTextAsync("../Talabat.Repository/Data/Seed/products.json");
            //    var Products = JsonSerializer.Deserialize<List<Product>>(ProductsData);
            //    if (Products?.Count > 0)
            //        await context.Set<Product>().AddRangeAsync(Products);
            //    await context.SaveChangesAsync();
            //}

            if (!context.Set<DeliveryMethod>().Any())
            {
                var DeliveryMethodsData = await File.ReadAllTextAsync("../Talabat.Repository/Data/Seed/delivery.json");
                var DeliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(DeliveryMethodsData);
                if (DeliveryMethods?.Count > 0)
                    await context.Set<DeliveryMethod>().AddRangeAsync(DeliveryMethods);
                await context.SaveChangesAsync();
            }

        }
    }
}
