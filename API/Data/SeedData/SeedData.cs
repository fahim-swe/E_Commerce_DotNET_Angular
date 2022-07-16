using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data.SeedData
{
    public class SeedData
    {
         public static async Task SeedUsers(StoreContext context)
       {
         string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).ToString();
        if(!context.ProductBrands.Any())
           {
               
                var seedData = await System.IO.File.ReadAllTextAsync("Data/SeedData/brands.json");
                var brands   = JsonSerializer.Deserialize<List<ProductBrand>>(seedData);

                foreach(var brand in brands)
                {
                    context.ProductBrands.Add(brand);
                }
                await context.SaveChangesAsync();
           }

           if(!context.ProductTypes.Any())
           {
                var seedData = await System.IO.File.ReadAllTextAsync("Data/SeedData/types.json");
                var types   = JsonSerializer.Deserialize<List<ProductType>>(seedData);

                foreach(var type in types)
                {
                    context.ProductTypes.Add(type);
                }
                await context.SaveChangesAsync();
           }

           if(!context.Product.Any()){
                var seedData = await System.IO.File.ReadAllTextAsync("Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(seedData);

                foreach(var product in products){

                    context.Product.Add(product);
                }
                await context.SaveChangesAsync();
           }
        }
    }
}