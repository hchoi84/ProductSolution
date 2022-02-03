using OpenQA.Selenium;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
  public class WithContext : IClassFixture<WebDriverFixture>
  {
    // for printing to the Test Detail Summary
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly WebDriverFixture _webDriverFixture;

    public WithContext(ITestOutputHelper testOutputHelper, WebDriverFixture webDriverFixture)
    {
      _testOutputHelper = testOutputHelper;
      _webDriverFixture = webDriverFixture;
    }

    [Fact]
    public void ClassFixtureTestNavigate()
    {
      _testOutputHelper.WriteLine("First test");
      _webDriverFixture.ChromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
    }

    [Theory]
    [InlineData("admin", "password")]
    [InlineData("admin1", "password1")]
    [InlineData("admin2", "password2")]
    [InlineData("admin3", "password3")]
    public void ClassFixtureTestFillData(string username, string password)
    {
      var driver = _webDriverFixture.ChromeDriver;
      driver.Navigate().GoToUrl("http://eaapp.somee.com");

      driver.FindElement(By.LinkText("Login")).Click();
      driver.FindElement(By.Id("UserName")).SendKeys(username);
      driver.FindElement(By.Id("Password")).SendKeys(password);
      driver.FindElement(By.CssSelector(".btn-default")).Click();

      _testOutputHelper.WriteLine("Test Completed");
    }
  }
}
