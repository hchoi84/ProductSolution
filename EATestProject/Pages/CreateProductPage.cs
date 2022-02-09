using EATestFramework.Driver;
using EATestProject.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EATestProject.Pages
{
  public class CreateProductPage : ICreateProductPage
  {
    private IWebDriver _driver;

    public CreateProductPage(IDriverFixture driverFixture)
    {
      _driver = driverFixture.Driver;
    }

    IWebElement TextInputName => _driver.FindElement(By.Id("Product_Name"));
    IWebElement TextInputDescription => _driver.FindElement(By.Id("Product_Description"));
    IWebElement TextInputPrice => _driver.FindElement(By.Id("Product_Price"));
    SelectElement? SelectProductType => new(_driver.FindElement(By.Id("Product_ProductType")));
    IWebElement ButtonCreate => _driver.FindElement(By.Id("Create"));

    public void EnterProductDetails(ProductModel productModel)
    {
      TextInputName.SendKeys(productModel.Name);
      TextInputDescription.SendKeys(productModel.Description);
      TextInputPrice.Clear();
      TextInputPrice.SendKeys(productModel.Price.ToString());
      SelectProductType?.SelectByValue(((int)productModel.ProductType).ToString());
      ButtonCreate.Submit();
    }
  }
}
