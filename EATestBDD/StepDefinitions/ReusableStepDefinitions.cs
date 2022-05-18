using ProductAPI.Data;
using ProductAPI.Repository;
using TechTalk.SpecFlow.Assist;

namespace EATestBDD.StepDefinitions;

[Binding]
public class ReusableStepDefinitions
{
  private readonly ScenarioContext _scenarioContext;
  private readonly IProductRepository _productRepository;

  public ReusableStepDefinitions(
    ScenarioContext scenarioContext,
    IProductRepository productRepository)
  {
    _scenarioContext = scenarioContext;
    _productRepository = productRepository;
  }

  [Given(@"I ensure the following product is created")]
  public void GivenIEnsureTheFollowingProductIsCreated(Table table)
  {
    ProductModel product = table.CreateInstance<ProductModel>();
    _productRepository.AddProduct(product);
  }


  [Then(@"I delete the product ([^""]*) for cleanup")]
  public void ThenIDeleteTheProductForCleanup(string productName)
  {
    _productRepository.DeleteProduct(productName);
  }
}
