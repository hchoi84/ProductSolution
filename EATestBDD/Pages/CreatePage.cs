﻿using EATestFramework.Driver;
using EATestFramework.Extensions;
using OpenQA.Selenium;
using ProductAPI.Data;

namespace EATestBDD.Pages
{
  public class CreatePage : ICreatePage
  {
    private IWebDriver _driver;

    public CreatePage(IDriverFixture driverFixture)
    {
      _driver = driverFixture.Driver;
    }

    IWebElement TextInputName => _driver.FindElement(By.Id("Product_Name"));
    IWebElement TextInputDescription => _driver.FindElement(By.Id("Product_Description"));
    IWebElement TextInputPrice => _driver.FindElement(By.Id("Product_Price"));
    IWebElement DropdownProductType => _driver.FindElement(By.Id("Product_ProductType"));
    IWebElement ButtonCreate => _driver.FindElement(By.Id("Create"));

    public void EnterProductDetails(ProductModel productModel)
    {
      TextInputName.ClearAndEnterText(productModel.Name);
      TextInputDescription.ClearAndEnterText(productModel.Description);
      TextInputPrice.Clear();
      TextInputPrice.ClearAndEnterText(productModel.Price.ToString());
      DropdownProductType.SelectDropdownByValue(((int)productModel.ProductType).ToString());
      ButtonCreate.Submit();
    }
  }
}
