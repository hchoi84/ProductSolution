using OpenQA.Selenium;
using SeleniumXUnitBasic.Driver;

namespace SeleniumXUnitBasic
{
  public class DriverFixture : IDriverFixture
  {
    private readonly IWebDriver _driver;
    private readonly IBrowserDriver _browserDriver;

    public IWebDriver Driver => _driver;

    public DriverFixture(IBrowserDriver browserDriver)
    {
      _browserDriver = browserDriver;
      _driver = GetWebDriver();
    }

    private IWebDriver GetWebDriver(BrowserType browserType = BrowserType.Chrome)
    {
      return browserType switch
      {
        BrowserType.Chrome => _browserDriver.GetChromeDriver(),
        BrowserType.Edge => _browserDriver.GetEdgeDriver(),
        _ => _browserDriver.GetChromeDriver()
      };
    }
  }
}
