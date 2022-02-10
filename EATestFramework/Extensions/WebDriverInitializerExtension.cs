using EATestFramework.Driver;
using EATestFramework.Settings;
using Microsoft.Extensions.DependencyInjection;

namespace EATestFramework.Extensions
{
  public static class WebDriverInitializerExtension
  {
    public static IServiceCollection UserWebDriverInitializer(this IServiceCollection services, BrowserTypeEnum browserType)
    {
      services.AddSingleton(new TestSettings
      {
        BrowserType = browserType
      });

      return services;
    }
  }
}
