using EATestFramework.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace EATestFramework.Driver
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
