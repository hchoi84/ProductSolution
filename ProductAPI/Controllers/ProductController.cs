using Microsoft.AspNetCore.Mvc;
using ProductAPI.Data;
using ProductAPI.Repository;

namespace ProductAPI.Controllers
{
  [ApiController]
  [Route("[controller]/[action]")]
  public class ProductController : ControllerBase
  {
    private readonly IProductRepository _productRepository;
    private const string _id = "{id}";

    public ProductController(IProductRepository productRepository)
    {
      _productRepository = productRepository;
    }

    [HttpGet]
    public ActionResult<List<Product>> GetAll()
    {
      return _productRepository.GetAllProducts();
    }

    [HttpGet(_id)]
    public Product GetById(int id)
    {
      return _productRepository.GetProductById(id);
    }

    [HttpPost]
    public Product Create(Product product)
    {
      return _productRepository.AddProduct(product);
    }

    [HttpPut]
    public Product Update(Product product)
    {
      return _productRepository.UpdateProduct(product);
    }

    [HttpDelete(_id)]
    public void DeleteById(int id)
    {
      _productRepository.DeleteProduct(id);
    }
  }
}
