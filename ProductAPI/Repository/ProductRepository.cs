using ProductAPI.Data;

namespace ProductAPI.Repository
{
  public class ProductRepository : IProductRepository
  {
    private readonly ProductDbContext _context;

    public ProductRepository(ProductDbContext context)
    {
      _context = context;
    }

    public List<ProductModel> GetAllProducts()
    {
      return _context.Products.ToList();
    }

    public ProductModel GetProductById(int id)
    {
      return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public ProductModel AddProduct(ProductModel product)
    {
      _context.Products.Add(product);
      _context.SaveChanges();
      return product;
    }

    public ProductModel UpdateProduct(ProductModel product)
    {
      _context.Products.Update(product);
      _context.SaveChanges();
      return product;
    }

    public void DeleteProduct(int id)
    {
      var product = _context.Products.FirstOrDefault(p => p.Id == id);
      _context.Products.Remove(product);
      _context.SaveChanges();
    }
  }
}