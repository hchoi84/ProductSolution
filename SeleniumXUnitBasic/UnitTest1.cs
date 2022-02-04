using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit;

namespace SeleniumXUnitBasic
{
  public class UnitTest1 : IClassFixture<DriverFixture>
  {
    private readonly IWebDriver _driver;

    public UnitTest1(DriverFixture driverFixture)
    {
      _driver = driverFixture.WebDriver;
      _driver.Navigate().GoToUrl(new Uri("https://localhost:7207/"));
    }

    [Fact]
    public void Test1()
    {
      _driver.FindElement(By.LinkText("Product")).Click();
      _driver.FindElement(By.LinkText("Create")).Click();

      _driver.FindElement(By.Id("Product_Name")).SendKeys("Table");
      _driver.FindElement(By.Id("Product_Description")).SendKeys("Standing Table");
      _driver.FindElement(By.Id("Product_Price")).Clear();
      _driver.FindElement(By.Id("Product_Price")).SendKeys("100");
      SelectElement? select = new(_driver.FindElement(By.Id("Product_ProductType")));
      select.SelectByValue("2");
      _driver.FindElement(By.Id("Create")).Submit();
    }

    [Fact]
    public void Test2()
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

    [Fact]
    public void Test3()
    {
      _driver.FindElement(By.LinkText("Product")).Click();
      _driver.FindElement(By.LinkText("Create")).Click();

      _driver.FindElement(By.Id("Product_Name")).SendKeys("Chair");
      _driver.FindElement(By.Id("Product_Description")).SendKeys("Sitting Chair");
      _driver.FindElement(By.Id("Product_Price")).Clear();
      _driver.FindElement(By.Id("Product_Price")).SendKeys("100");
      SelectElement? select = new(_driver.FindElement(By.Id("Product_ProductType")));
      select.SelectByValue("3");
      _driver.FindElement(By.Id("Create")).Submit();
    }
  }
}