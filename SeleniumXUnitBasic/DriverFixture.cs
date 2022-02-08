using OpenQA.Selenium;
using SeleniumXUnitBasic.Driver;
using System;

namespace SeleniumXUnitBasic
{
  public class DriverFixture : IDisposable
  {
    private readonly IWebDriver _driver;

    public IWebDriver WebDriver { get { return _driver; } }

    public DriverFixture(BrowserType browserType)
    {
      _driver = GetWebDriver(browserType);
    }

    private IWebDriver GetWebDriver(BrowserType browserType)
    {
      BrowserDriver browserDriver = new();
      return browserType switch
      {
        BrowserType.Chrome => browserDriver.GetChromeDriver(),
        BrowserType.Edge => browserDriver.GetEdgeDriver(),
        _ => browserDriver.GetChromeDriver()
      };
    }

    public void Dispose()
    {
      _driver.Quit();
    }
  }
}
