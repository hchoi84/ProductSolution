using OpenQA.Selenium;

namespace SeleniumXUnitBasic.Driver
{
  public interface IDriverFixture
  {
    IWebDriver Driver { get; }
  }
}