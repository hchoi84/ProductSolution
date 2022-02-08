using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace SeleniumXUnitBasic
{
  public class UnitTest2 : IClassFixture<DriverFixture>
  {
    private readonly IWebDriver _driver;

    public UnitTest2(DriverFixture driverFixture)
    {
      _driver = driverFixture.WebDriver;
      _driver.Navigate().GoToUrl(new Uri("https://localhost:7207/"));
    }

    [Fact]
    public void Test4()
    {
      _driver.FindElement(By.LinkText("Product")).Click();
      _driver.FindElement(By.LinkText("Create")).Click();

      _driver.FindElement(By.Id("Product_Name")).SendKeys("Motherboard");
      _driver.FindElement(By.Id("Product_Description")).SendKeys("Computer board");
      _driver.FindElement(By.Id("Product_Price")).Clear();
      _driver.FindElement(By.Id("Product_Price")).SendKeys("100");
      SelectElement? select = new(_driver.FindElement(By.Id("Product_ProductType")));
      select.SelectByValue("1");
      _driver.FindElement(By.Id("Create")).Submit();
    }

    [Fact]
    public void Test5()
    {
      _driver.FindElement(By.LinkText("Product")).Click();
      _driver.FindElement(By.LinkText("Create")).Click();

      _driver.FindElement(By.Id("Product_Name")).SendKeys("Desk");
      _driver.FindElement(By.Id("Product_Description")).SendKeys("Standing Desk");
      _driver.FindElement(By.Id("Product_Price")).Clear();
      _driver.FindElement(By.Id("Product_Price")).SendKeys("100");
      SelectElement? select = new(_driver.FindElement(By.Id("Product_ProductType")));
      select.SelectByValue("2");
      _driver.FindElement(By.Id("Create")).Submit();
    }
  }
}