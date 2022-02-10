using EATestFramework.Driver;
using EATestFramework.Extensions;
using EATestProject.Pages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EATestProject
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      IConfigurationRoot? config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
      string? browserTypeValue = config.GetSection("BrowserType").Value;
      BrowserTypeEnum browserType = string.IsNullOrEmpty(browserTypeValue)
        ? BrowserTypeEnum.Chrome
        : Enum.Parse<BrowserTypeEnum>(browserTypeValue, true);

      services.UserWebDriverInitializer(browserType);
      services.AddScoped<IBrowserDriver, BrowserDriver>();
      services.AddScoped<IDriverFixture, DriverFixture>();
      services.AddScoped<IHomePage, HomePage>();
      services.AddScoped<ICreateProductPage, CreateProductPage>();
    }
  }
}
