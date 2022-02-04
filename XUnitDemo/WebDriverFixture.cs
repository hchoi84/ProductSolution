using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace XUnitDemo
{
  public class WebDriverFixture : IDisposable
  {
    public ChromeDriver ChromeDriver { get; private set; }

    public WebDriverFixture()
    {
      new DriverManager().SetUpDriver(new ChromeConfig());
      ChromeDriver = new();
    }

    public void Dispose()
    {
      ChromeDriver.Quit();
      ChromeDriver.Dispose();
    }
  }
}
