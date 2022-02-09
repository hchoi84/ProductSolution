using EATestFramework.Driver;
using OpenQA.Selenium;

namespace EATestProject.Pages
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

    public void CreateProduct()
    {
      LinkProduct.Click();
      LinkCreate.Click();
    }
  }
}
