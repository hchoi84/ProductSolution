using Autofac;
using OpenQA.Selenium;
using SeleniumXUnitBasic.Driver;
using System;

namespace SeleniumXUnitBasic
{
  public class DriverFixture : IDisposable
  {
    private readonly IWebDriver _driver;
    private readonly IContainer _container;

    public IWebDriver Driver => _driver;

    public DriverFixture(IContainer container, BrowserType browserType)
    {
      _container = container;
      _driver = GetWebDriver(browserType);
    }

    private IWebDriver GetWebDriver(BrowserType browserType)
    {
      IBrowserDriver browserDriver = _container.Resolve<IBrowserDriver>();
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
