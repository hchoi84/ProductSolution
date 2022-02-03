using OpenQA.Selenium;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
  //[Collection("Sequence")]
  public class ParallelTest : IClassFixture<WebDriverFixture>
  {
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly WebDriverFixture _webDriverFixture;

    public ParallelTest(ITestOutputHelper testOutputHelper, WebDriverFixture webDriverFixture)
    {
      _testOutputHelper = testOutputHelper;
      _webDriverFixture = webDriverFixture;
    }

    //[Theory]
    //[InlineData("admin", "password")]
    //[InlineData("admin1", "password1")]
    //[InlineData("admin2", "password2")]
    //[InlineData("admin3", "password3")]
    //public void ClassFixtureTestTheory(string username, string password)
    //{
    //  var driver = _webDriverFixture.ChromeDriver;
    //  driver.Navigate().GoToUrl("http://eaapp.somee.com");

    //  driver.FindElement(By.LinkText("Login")).Click();
    //  driver.FindElement(By.Id("UserName")).SendKeys(username);
    //  driver.FindElement(By.Id("Password")).SendKeys(password);
    //  //driver.FindElement(By.CssSelector(".btn-default")).Click();

    //  _testOutputHelper.WriteLine("Test Completed");
    //}

    [Theory]
    [MemberData(nameof(Data))]
    //https://andrewlock.net/creating-parameterised-tests-in-xunit-with-inlinedata-classdata-and-memberdata/
    public void ClassFixtureTestMemberData(string un, string pwd, string cpwd, string email)
    {
      var driver = _webDriverFixture.ChromeDriver;
      driver.Navigate().GoToUrl("http://eaapp.somee.com");

      driver.FindElement(By.LinkText("Register")).Click();
      driver.FindElement(By.Id("UserName")).SendKeys(un);
      driver.FindElement(By.Id("Password")).SendKeys(pwd);
      driver.FindElement(By.Id("ConfirmPassword")).SendKeys(cpwd);
      driver.FindElement(By.Id("Email")).SendKeys(email);

      _testOutputHelper.WriteLine("Test Completed");
    }

    public static IEnumerable<object[]> Data => new List<object[]>
    {
      new object[]
      {
        "UserName1", "Password1", "Password1", "abc1@email.com"
      },
      new object[]
      {
        "UserName2", "Password2", "Password2", "abc2@email.com"
      },
      new object[]
      {
        "UserName3", "Password3", "Password3", "abc3@email.com"
      }
    };
  }
}
