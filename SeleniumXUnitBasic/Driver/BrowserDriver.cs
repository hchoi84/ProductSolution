using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnitBasic.Driver
{
  public class BrowserDriver
  {
    public IWebDriver GetChromeDriver()
    {
      new DriverManager().SetUpDriver(new ChromeConfig());
      return new ChromeDriver();
    }

    public IWebDriver GetEdgeDriver()
    {
      new DriverManager().SetUpDriver(new EdgeConfig());
      return new EdgeDriver();
    }
  }
}
