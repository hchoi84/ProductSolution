using OpenQA.Selenium.Chrome;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;
using Xunit.Abstractions;

namespace XUnitDemo
{
  public class AWithoutContext
  {
    // for printing to the Test Detail Summary
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly ChromeDriver _chromeDriver;

    public AWithoutContext(ITestOutputHelper testOutputHelper)
    {
      _testOutputHelper = testOutputHelper;
      //sets up the appropriate driver version for the referenced browser
      new DriverManager().SetUpDriver(new ChromeConfig());
      _chromeDriver = new();
    }

    [Fact]
    public void Test1()
    {
      Console.WriteLine("First test");
      _testOutputHelper.WriteLine("First test");
      _chromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
    }
  }
}