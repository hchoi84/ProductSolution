using AutoFixture.Xunit2;
using EATestProject.Models;
using EATestProject.Pages;
using OpenQA.Selenium;
using Xunit;

namespace EATestProject
{
  public class UnitTest1
  {
    private readonly IHomePage _homePage;
    private readonly ICreateProductPage _createProductPage;
    private IWebDriver _driver;

    public UnitTest1(IHomePage homePage, ICreateProductPage createProductPage)
    {
      _homePage = homePage;
      _createProductPage = createProductPage;
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

    //Autodo will auto generate the data for ProductModel
    [Theory, AutoData]
    public void Test2(ProductModel product)
    {
      _homePage.CreateProduct();
      _createProductPage.EnterProductDetails(product);
    }
  }
}