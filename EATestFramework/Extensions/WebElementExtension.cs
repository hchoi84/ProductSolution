using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace EATestFramework.Extensions
{
  public static class WebElementExtension
  {
    public static void SelectDropdownByValue(this IWebElement webElement, string value)
    {
      SelectElement selectElement = new(webElement);
      selectElement.SelectByValue(value);
    }

    public static void SelectDropdownByText(this IWebElement webElement, string text)
    {
      SelectElement selectElement = new(webElement);
      selectElement.SelectByText(text);
    }

    public static void SelectDropdownByIndex(this IWebElement webElement, int index)
    {
      SelectElement selectElement = new(webElement);
      selectElement.SelectByIndex(index);
    }

    public static void ClearAndEnterText(this IWebElement webElement, string value)
    {
      webElement.Clear();
      webElement.SendKeys(value);
    }

    public static string GetSelectedDropdownValue(this IWebElement webElement)
    {
      return new SelectElement(webElement).SelectedOption.Text;
    }
  }
}
