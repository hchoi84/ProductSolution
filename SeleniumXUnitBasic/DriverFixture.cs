using OpenQA.Selenium;
using SeleniumXUnitBasic.Driver;
using System;

namespace SeleniumXUnitBasic
{
  public class DriverFixture : IDisposable
  {
    private readonly IWebDriver _driver;
    private readonly IBrowserDriver _browserDriver;

    public IWebDriver Driver => _driver;

    public DriverFixture(IBrowserDriver browserDriver, BrowserType browserType)
    {
      _browserDriver = browserDriver;
      _driver = GetWebDriver(browserType);
    }

    private IWebDriver GetWebDriver(BrowserType browserType)
    {
      return browserType switch
      {
        BrowserType.Chrome => _browserDriver.GetChromeDriver(),
        BrowserType.Edge => _browserDriver.GetEdgeDriver(),
        _ => _browserDriver.GetChromeDriver()
      };
    }

    public void Dispose()
    {
      _driver.Quit();
    }
  }
}
