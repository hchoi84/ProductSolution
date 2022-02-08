using OpenQA.Selenium;

namespace SeleniumXUnitBasic
{
  public interface IDriverFixture
  {
    IWebDriver Driver { get; }
  }
}