using EATestBDD.Models;
using EATestFramework.Driver;
using OpenQA.Selenium;
using System;

namespace EATestBDD.Pages
{
  public class DetailPage : IDetailPage
  {
    private IWebDriver _driver;

    public DetailPage(IDriverFixture driverFixture)
    {
      _driver = driverFixture.Driver;
    }

    IWebElement TextInputName => _driver.FindElement(By.Id("Name"));
    IWebElement TextInputDescription => _driver.FindElement(By.Id("Description"));
    IWebElement TextInputPrice => _driver.FindElement(By.Id("Price"));
    IWebElement DropdownProductType => _driver.FindElement(By.Id("ProductType"));

    public ProductModel GetProductDetails()
    {
      return new()
      {
        Name = TextInputName.Text,
        Description = TextInputDescription.Text,
        Price = int.Parse(TextInputPrice.Text),
        ProductType = (ProductTypeEnum)Enum.Parse(typeof(ProductTypeEnum), DropdownProductType.GetAttribute("innerText").ToString())
      };
    }
  }
}
