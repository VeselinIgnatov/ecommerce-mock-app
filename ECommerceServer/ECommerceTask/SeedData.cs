using Domain.Entities;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Web
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                if (dbContext.Products.Any()) return;
                PopulateTestData(dbContext);
            }
        }
        private static void PopulateTestData(AppDbContext context)
        {
            var httpClient = new HttpClient();
            var data = httpClient.GetAsync("https://dummyjson.com/products").Result;
            var str = data.Content.ReadAsStringAsync().Result;
            try
            {

                var result = JsonConvert.DeserializeObject<Root>(str);
                //var categories = result.products.SelectMany(x => new Category
                //{

                //});

                //var categories = context.Categories.ToList();
                //var newProducts = new List<Product>();

                foreach (var fakeProduct in result.products)
                {
                    //var brand = context.Brands.Where(x => x.Name == product.brand).FirstOrDefault();
                    //var category = context.Categories.Where(x => x.Name == product.category).FirstOrDefault();

                    //newProducts.Add(new Product
                    //{
                    //    Name = product.title,
                    //    Description = product.description,
                    //    BrandId = brand.Id,
                    //    Brand = brand,
                    //    Categories = new List<Category> { category },
                    //    ImageUrl = product.thumbnail,
                    //    Price = product.price,
                    //    Quantity = product.stock,
                    //    Rating = product.rating
                    //});

                    // Create or get brand entity
                    Brand brand = context.Brands.FirstOrDefault(b => b.Name == fakeProduct.brand);
                    if (brand == null)
                    {
                        brand = new Brand
                        {
                            Name = fakeProduct.brand,
                            // Set other properties if needed
                        };
                        context.Brands.Add(brand);
                    }

                    // Create or get category entity
                    Category category = context.Categories.FirstOrDefault(c => c.Name == fakeProduct.category);
                    if (category == null)
                    {
                        category = new Category
                        {
                            Name = fakeProduct.category,
                            // Set other properties if needed
                        };
                        context.Categories.Add(category);
                    }

                    // Create product entity
                    Product product = new Product
                    {
                        Name = fakeProduct.title,
                        Description = fakeProduct.description,
                        Price = fakeProduct.price,
                        Quantity = fakeProduct.stock,
                        Rating = fakeProduct.rating,
                        ImageUrl = fakeProduct.thumbnail,
                        Brand = brand,
                        // Add category to product if needed
                    };

                    // Add product to categories
                    category.Products.Add(product);

                    // Add product to context
                    context.Products.Add(product);
                }

                // Save changes to the database
                context.SaveChanges();

            }
            catch (Exception ex)
            { }
        }
    }

}

public class FakeProduct
{
    public int id { get; set; }
    public string title { get; set; }
    public string description { get; set; }
    public int price { get; set; }
    public double discountPercentage { get; set; }
    public double rating { get; set; }
    public int stock { get; set; }
    public string brand { get; set; }
    public string category { get; set; }
    public string thumbnail { get; set; }
    public List<string> images { get; set; }
}

public class Root
{
    public List<FakeProduct> products { get; set; }
    public int total { get; set; }
    public int skip { get; set; }
    public int limit { get; set; }
}
