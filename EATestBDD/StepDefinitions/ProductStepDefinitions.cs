using EATestBDD.Models;
using EATestBDD.Pages;
using TechTalk.SpecFlow.Assist;

namespace EATestBDD.StepDefinitions
{
  [Binding]
  public class ProductStepDefinitions
  {
    private readonly ScenarioContext _scenarioContext;
    private readonly IHomePage _homePage;
    private readonly ICreatePage _createPage;
    private readonly IDetailPage _detailPage;

    public ProductStepDefinitions(
      ScenarioContext scenarioContext,
      IHomePage homePage,
      ICreatePage createPage,
      IDetailPage detailPage)
    {
      _scenarioContext = scenarioContext;
      _homePage = homePage;
      _createPage = createPage;
      _detailPage = detailPage;
    }

    [Given(@"I click the Product menu")]
    public void GivenIClickTheProductMenu()
    {
      _homePage.ClickProduct();
    }

    [Given(@"I click the ""([^""]*)"" link")]
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

    [When(@"I click the details link of the newly created product")]
    public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct()
    {
      ProductModel product = _scenarioContext.Get<ProductModel>();
      _homePage.PerformClickOnSpecialValue(product.Name, "Details");
    }

    [Then(@"I see all the product details are created as expected")]
    public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
    {
      ProductModel product = _scenarioContext.Get<ProductModel>();
      ProductModel? actualProduct = _detailPage.GetProductDetails();
      actualProduct.Should().BeEquivalentTo(product, option => option.Excluding(x => x.Id));
    }
  }
}
