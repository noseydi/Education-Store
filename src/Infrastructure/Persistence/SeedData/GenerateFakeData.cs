using Domain.Entities;
using Infrastructure.Persistence.Context;
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



        public static List<Product> Products()
        {
            return new List<Product>()
                        {
                    new()
                    {
                        Description = "",
                        Title= "Bag 1",
                        Summary =   "summary",
                        Price=15000,
                        PictureUrl="11.jpeg",
                           ProductTypeId=3,
 ProductBrandId=3,
  Name="Bag 1",
   

                    },
                     new()
                    {
                        Description = "",
                        Title= "Bag 2",
                        Summary =   "summary",
                        Price=15000,
                        PictureUrl="12.jpeg",
                           ProductTypeId=3,
 ProductBrandId=3,
  Name="Bag 2",


                    }
                    };
        }

        public static List<ProductBrand> ProductBrands()
        {
            return new List<ProductBrand>()
                        {
                    new()
                    {
                        Description = "brand 1 boofaloo",
                        Title= "Title",
                        Summary =   "summary boofalo",

                    },
                    new()
                    {
                        Description = "brand 2 mashhad",
                        Title= "Title",
                        Summary =   "summary mashhad",

                    }
                    };
        }
        public static List<ProductType> ProductTypes()
        {
            return new List<ProductType>()
                        {
                    new()
                    {
                        Description = "type 1_ shoes",
                        Title= "type 1",
                        Summary =   "summary type 1 ",
                    },
                      new()
                    {
                        Description = "type 2 _ bags",
                        Title= "type 2",
                        Summary =   "summary type 2",
                      }
                    };
        }

    }
}