using AutoFixture;
using OpenQA.Selenium;
using System.Net.Mail;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
  public class CAutoFixture : IClassFixture<WebDriverFixture>
  {
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly WebDriverFixture _webDriverFixture;

    public CAutoFixture(ITestOutputHelper testOutputHelper, WebDriverFixture webDriverFixture)
    {
      _testOutputHelper = testOutputHelper;
      _webDriverFixture = webDriverFixture;
    }

    [Fact]
    public void ClassFixtureTestMemberData()
    {
      var driver = _webDriverFixture.ChromeDriver;
      driver.Navigate().GoToUrl("http://eaapp.somee.com");

      //using AutoFixture, we can create a random value for specified type. However, it's creating some sort of GUID for string
      var un = new Fixture().Create<string>();
      var pwd = new Fixture().Create<string>();
      var cpwd = new Fixture().Create<string>();
      var mailAddress = new Fixture().Create<MailAddress>();
      
      driver.FindElement(By.LinkText("Register")).Click();
      driver.FindElement(By.Id("UserName")).SendKeys(un);
      driver.FindElement(By.Id("Password")).SendKeys(pwd);
      driver.FindElement(By.Id("ConfirmPassword")).SendKeys(cpwd);
      driver.FindElement(By.Id("Email")).SendKeys(mailAddress.Address);

      _testOutputHelper.WriteLine("Test Completed");
    }
  }
}
