using ProductWeb.Models;

namespace ProductWeb.API
{
  public interface IConnector
  {
    HttpClient Client { get; }

    Task CreateAsync(Product product);
    Task DeleteByIdAsync(int id);
    Task<List<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task UpdateAsync(Product product);
  }
}