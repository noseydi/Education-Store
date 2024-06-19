using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Persistence.SeedData
{
    public class GenerateFakeData

    {
        public static async Task SeedDataAsync(ApplicationDbContext context, ILoggerFactory LoggerFactory)

        {
            try
            {

              
                if (!await context.productstype.AnyAsync())
                {
                    var brands = ProductBrands();
                    await context.productbrand.AddRangeAsync(brands);
                    await context.SaveChangesAsync();
                }
                if (!await context.productstype.AnyAsync())
                {
                    var types = ProductTypes();
                    await context.productstype.AddRangeAsync(types);
                    await context.SaveChangesAsync();
                }
                if (!await context.products.AnyAsync())
                {
                    var products = Products();
                    await context.products.AddRangeAsync(products);
                    await context.SaveChangesAsync();

                }
            }
            catch (Exception ex)
            {
                ILogger logger = LoggerFactory.CreateLogger<GenerateFakeData>();
                logger.LogError(ex, message: ex.Message);
            }
        }



        public static List<Products> Products()
        {
            return new List<Products>()
                        {
                    new()
                    {
                        Description = "",
                        Title= "Title",
                        Summary =   "summary",
                        Price=15000,
                        PictureUrl="",
                           ProductTypeId=1,
 ProductBrandId=1,
  Name="product1",
   

                    }
                    };
        }

        public static List<ProductBrand> ProductBrands()
        {
            return new List<ProductBrand>()
                        {
                    new()
                    {
                        Description = "111111111111",
                        Title= "Title1111111111111111",
                        Summary =   "summary111111111111111",

                    },
                    new()
                    {
                        Description = "222222222222222",
                        Title= "Title2222222222222222",
                        Summary =   "summary2222222222222222",

                    }
                    };
        }
        public static List<ProductType> ProductTypes()
        {
            return new List<ProductType>()
                        {
                    new()
                    {
                        Description = "11111111",
                        Title= "Title",
                        Summary =   "summary11111111",
                    },
                      new()
                    {
                        Description = "22222",
                        Title= "Title",
                        Summary =   "summary2222222222",
                    }
                    };
        }

    }
}