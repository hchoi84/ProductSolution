using AutoFixture;
using AutoFixture.Xunit2;
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
    public void AutoFixtureTest()
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

    [Fact]
    public void AutoFixtureTestWithClass()
    {
      var driver = _webDriverFixture.ChromeDriver;
      driver.Navigate().GoToUrl("http://eaapp.somee.com");

      //using AutoFixture, we can create a random value for specified type.
      //var user = new Fixture().Create<RegisterUserModel>();
      //var user = new Fixture().Build<RegisterUserModel>().Without(x => x.Email).Create();
      var user = new Fixture().Build<RegisterUserModel>().With(x => x.Email, "abc@ea.com").Create();

      driver.FindElement(By.LinkText("Register")).Click();
      driver.FindElement(By.Id("UserName")).SendKeys(user.Name);
      driver.FindElement(By.Id("Password")).SendKeys(user.Password);
      driver.FindElement(By.Id("ConfirmPassword")).SendKeys(user.CPassword);
      driver.FindElement(By.Id("Email")).SendKeys(user.Email);

      _testOutputHelper.WriteLine("Test Completed");
    }

    //14-138 The AutoData calls AutoFixture. Replaces the logic of AutoFixture with the AutoData attribute.
    [Theory, AutoData]
    public void AutoDataTest(RegisterUserModel user)
    {
      var driver = _webDriverFixture.ChromeDriver;
      driver.Navigate().GoToUrl("http://eaapp.somee.com");

      driver.FindElement(By.LinkText("Register")).Click();
      driver.FindElement(By.Id("UserName")).SendKeys(user.Name);
      driver.FindElement(By.Id("Password")).SendKeys(user.Password);
      driver.FindElement(By.Id("ConfirmPassword")).SendKeys(user.CPassword);
      driver.FindElement(By.Id("Email")).SendKeys(user.Email);

      _testOutputHelper.WriteLine("Test Completed");
    }
  }
}
