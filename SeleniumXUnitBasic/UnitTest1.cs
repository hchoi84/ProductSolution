using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace SeleniumXUnitBasic
{
  public class UnitTest1
  {
    private IWebDriver _driver;

    [Fact]
    public void Test1()
    {
      new DriverManager().SetUpDriver(new ChromeConfig());
      _driver = new ChromeDriver();

      _driver.Navigate().GoToUrl(new Uri("https://localhost:7207/"));
      _driver.FindElement(By.LinkText("Product")).Click();
      _driver.FindElement(By.LinkText("Create")).Click();

      _driver.FindElement(By.Id("Product_Name")).SendKeys("Table");
      _driver.FindElement(By.Id("Product_Description")).SendKeys("Standing Table");
      _driver.FindElement(By.Id("Product_Price")).Clear();
      _driver.FindElement(By.Id("Product_Price")).SendKeys("100");
      SelectElement? select = new(_driver.FindElement(By.Id("Product_ProductType")));
      select.SelectByValue("2");
      _driver.FindElement(By.Id("Create")).Submit();
      _driver.Quit();
    }
  }
}