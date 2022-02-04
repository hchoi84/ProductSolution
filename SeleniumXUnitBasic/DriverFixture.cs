using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumXUnitBasic
{
  public class DriverFixture : IDisposable
  {
    private readonly IWebDriver _driver;

    public IWebDriver WebDriver { get { return _driver; } }

    public DriverFixture()
    {
      new DriverManager().SetUpDriver(new ChromeConfig());
      _driver = new ChromeDriver();
    }

    public void Dispose()
    {
      _driver.Quit();
    }
  }
}
