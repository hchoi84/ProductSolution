using ProductWeb.Models;

namespace ProductWeb.API
{
  public interface IConnector
  {
    HttpClient Client { get; }

    Task<List<Product>> GetAllAsync();
  }
}