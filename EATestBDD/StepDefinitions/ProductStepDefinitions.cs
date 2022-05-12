using EATestBDD.Models;
using EATestBDD.Pages;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace EATestBDD.StepDefinitions
{
  [Binding]
  public class ProductStepDefinitions
  {
    private readonly IHomePage _homePage;
    private readonly ICreatePage _createPage;
    private readonly IDetailPage _detailPage;

    public ProductStepDefinitions(IHomePage homePage, ICreatePage createPage, IDetailPage detailPage)
    {
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
      _createPage.EnterProductDetails(product);
    }

    [When(@"I click the details link of the newly created product")]
    public void WhenIClickTheDetailsLinkOfTheNewlyCreatedProduct()
    {
      throw new PendingStepException();
    }

    [Then(@"I see all the product details are created as expected")]
    public void ThenISeeAllTheProductDetailsAreCreatedAsExpected()
    {
      throw new PendingStepException();
    }
  }
}
