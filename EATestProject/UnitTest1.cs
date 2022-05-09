using AutoFixture.Xunit2;
using EATestProject.Models;
using EATestProject.Pages;
using FluentAssertions;
using OpenQA.Selenium;
using Xunit;

namespace EATestProject
{
  public class UnitTest1
  {
    private readonly IHomePage _homePage;
    private readonly ICreatePage _createPage;
    private readonly IDetailPage _detailPage;
    private IWebDriver _driver;

    public UnitTest1(IHomePage homePage, ICreatePage createPage, IDetailPage detailPage)
    {
      _homePage = homePage;
      _createPage = createPage;
      _detailPage = detailPage;
    }

    //[Fact]
    //public void Test1()
    //{
    //  _homePage.CreateProduct();
    //  _createProductPage.EnterProductDetails(new ProductModel
    //  {
    //    Name = "AutoProduct",
    //    Description = "AutoDescription",
    //    Price = 123,
    //    ProductType = ProductTypeEnum.PERIPHARALS
    //  });
    //}

    //Autodata will auto generate the data for ProductModel based on property type.
    //Part of AutoFixture framework
    [Theory, AutoData]
    public void Test2(ProductModel product)
    {
      _homePage.CreateProduct();
      _createPage.EnterProductDetails(product);
    }

    [Theory, AutoData]
    public void Test3(ProductModel product)
    {
      _homePage.CreateProduct();
      _createPage.EnterProductDetails(product);
      _homePage.PerformClickOnSpecialValue(product.Name, "Details");
      ProductModel newProductDetail = _detailPage.GetProductDetails();

      //Part of FluentAssertion
      newProductDetail.Should().Be(product);
    }

    [Theory, AutoData]
    public void Test4(ProductModel product)
    {
      _homePage.CreateProduct();
      _createPage.EnterProductDetails(product);
      _homePage.PerformClickOnSpecialValue("Monitor", "Details");
    }
  }
}