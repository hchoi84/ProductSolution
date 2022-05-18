using EATestFramework.Driver;
using EATestFramework.Extensions;
using OpenQA.Selenium;
using ProductAPI.Data;

namespace EATestBDD.Pages
{
  public class EditPage : IEditPage
  {
    private readonly IWebDriver _driver;

    public EditPage(IDriverFixture driverFixture)
    {
      _driver = driverFixture.Driver;
    }

    IWebElement TextInputName => _driver.FindElement(By.Id("Product_Name"));
    IWebElement TextInputDescription => _driver.FindElement(By.Id("Product_Description"));
    IWebElement TextInputPrice => _driver.FindElement(By.Id("Product_Price"));
    IWebElement TextInputProductType => _driver.FindElement(By.Id("Product_ProductType"));
    IWebElement ButtonSave => _driver.FindElement(By.XPath("//input[@value='Save']"));

    public void EditProductDetails(ProductModel product)
    {
      TextInputName.ClearAndEnterText(product.Name);
      TextInputDescription.ClearAndEnterText(product.Description);
      TextInputPrice.ClearAndEnterText(product.Price.ToString());
      TextInputProductType.ClearAndEnterText(product.ProductType.ToString());
      ButtonSave.Submit();
    }
  }
}
