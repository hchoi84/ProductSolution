using Microsoft.Extensions.DependencyInjection;
using SeleniumXUnitBasic.Settings;

namespace SeleniumXUnitBasic.Driver
{
  public static class WebDriverInitializerExtension
  {
    public static IServiceCollection UserWebDriverInitializer(this IServiceCollection services, BrowserType browserType)
    {
      services.AddSingleton(new TestSettings
      {
        BrowserType = browserType
      });

      return services;
    }
  }
}
