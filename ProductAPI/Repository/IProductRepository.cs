using ProductAPI.Data;

namespace ProductAPI.Repository
{
  public interface IProductRepository
    {
        ProductModel AddProduct(ProductModel product);
        void DeleteProduct(int id);
        List<ProductModel> GetAllProducts();
        ProductModel GetProductById(int id);
        ProductModel UpdateProduct(ProductModel product);
    }
}