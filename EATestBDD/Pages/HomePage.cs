using EATestFramework.Driver;
using EATestFramework.Extensions;
using OpenQA.Selenium;

namespace EATestBDD.Pages
{
  public class HomePage : IHomePage
  {
    private IWebDriver _driver;

    public HomePage(IDriverFixture driverFixture)
    {
      _driver = driverFixture.Driver;
    }

    IWebElement LinkProduct => _driver.FindElement(By.LinkText("Product"));
    IWebElement LinkCreate => _driver.FindElement(By.LinkText("Create"));
    IWebElement tableList => _driver.FindElement(By.CssSelector(".table"));

    public void CreateProduct()
    {
      LinkProduct.Click();
      LinkCreate.Click();
    }

    public void PerformClickOnSpecialValue(string name, string operation)
    {
      tableList.PerformActionOnCell("5", "Name", name, operation);
    }
  }
}
