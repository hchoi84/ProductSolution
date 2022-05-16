using Microsoft.EntityFrameworkCore;

namespace ProductAPI.Data
{
  public class ProductDbContext : DbContext
  {
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {

    }

    public DbSet<ProductModel> Products { get; set; }
  }
}
