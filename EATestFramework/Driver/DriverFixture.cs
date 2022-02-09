using EATestFramework.Settings;
using OpenQA.Selenium;

namespace EATestFramework.Driver
{
  public class DriverFixture : IDriverFixture
  {
    private readonly IWebDriver _driver;
    private readonly TestSettings _testSettings;
    private readonly IBrowserDriver _browserDriver;

    public IWebDriver Driver => _driver;

    public DriverFixture(TestSettings testSettings, IBrowserDriver browserDriver)
    {
      _testSettings = testSettings;
      _browserDriver = browserDriver;
      _driver = GetWebDriver();
    }

    private IWebDriver GetWebDriver()
    {
      return _testSettings.BrowserType switch
      {
        BrowserTypeEnum.Chrome => _browserDriver.GetChromeDriver(),
        BrowserTypeEnum.Edge => _browserDriver.GetEdgeDriver(),
        _ => _browserDriver.GetChromeDriver()
      };
    }
  }
}
