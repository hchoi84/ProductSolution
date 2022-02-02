using ProductAPI.Data;

namespace ProductAPI.Repository
{
  public interface IProductRepository
    {
        Product AddProduct(Product product);
        void DeleteProduct(int id);
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        Product UpdateProduct(Product product);
    }
}