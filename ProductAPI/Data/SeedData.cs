namespace ProductAPI.Data;

public static class SeedData
{
  public static void Seed(this ProductDbContext context)
  {
    if (!context.Products.Any())
    {
      List<ProductModel> products = new()
      {
        new()
        {
          Name = "Keyboard",
          Description = "Gaming Keyboard with lights",
          Price = 150,
          ProductType = ProductTypeEnum.PERIPHARALS
        },
        new()
        {
          Name = "Mouse",
          Description = "Gaming Mouse",
          Price = 40,
          ProductType = ProductTypeEnum.PERIPHARALS
        },
        new()
        {
          Name = "Monitor",
          Description = "HD monitor",
          Price = 400,
          ProductType = ProductTypeEnum.MONITOR
        },
        new()
        {
          Name = "Cabinet",
          Description = "Business Cabinet with lights",
          Price = 60,
          ProductType = ProductTypeEnum.EXTERNAL,
        }
      };

      context.Products.AddRange(products);
      context.SaveChanges();
    }
  }
}
