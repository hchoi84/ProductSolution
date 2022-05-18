using EATestBDD.Pages;
using ProductAPI.Data;
using ProductAPI.Repository;
using TechTalk.SpecFlow.Assist;

namespace EATestBDD.StepDefinitions;

[Binding]
public class ProductStepDefinitions
{
  private readonly ScenarioContext _scenarioContext;
  private readonly IHomePage _homePage;
  private readonly ICreatePage _createPage;
  private readonly IDetailPage _detailPage;
  private readonly IProductRepository _productRepository;

  public ProductStepDefinitions(
    ScenarioContext scenarioContext,
    IHomePage homePage,
    ICreatePage createPage,
    IDetailPage detailPage,
    IProductRepository productRepository)
  {
    _scenarioContext = scenarioContext;
    _homePage = homePage;
    _createPage = createPage;
    _detailPage = detailPage;
    _productRepository = productRepository;
  }

  [Given(@"I click the Product menu")]
  public void GivenIClickTheProductMenu()
  {
    _homePage.ClickProduct();
  }

  [Given(@"I click the ([^""]*) link")]
  public void GivenIClickTheLink(string create)
  {
    _homePage.ClickCreate();
  }

  [Given(@"I create product with following details")]
  public void GivenICreateProductWithFollowingDetails(Table table)
  {
    ProductModel product = table.CreateInstance<ProductModel>();
    _scenarioContext.Set(product);
    _createPage.EnterProductDetails(product);
  }

  [When(@"I Edit the product details with following")]
  public void WhenIEditTheProductDetailsWithFollowing(Table table)
  {
    ProductModel product = table.CreateInstance<ProductModel>();
  }


  [When(@"I click the ([^""]*) link of the newly created product")]
  public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct(string operation)
  {
    ProductModel product = _scenarioContext.Get<ProductModel>();
    _homePage.PerformClickOnSpecialValue(product.Name, operation);
  }

  [Then(@"I see all the product details are created as expected")]
  public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
  {
    ProductModel product = _scenarioContext.Get<ProductModel>();
    ProductModel? actualProduct = _detailPage.GetProductDetails();
    actualProduct.Should().BeEquivalentTo(product, option => option.Excluding(x => x.Id));
  }
}
