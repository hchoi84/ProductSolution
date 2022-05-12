using EATestFramework.Driver;
using EATestFramework.Extensions;
using EATestBDD.Pages;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;

namespace EATestBDD;

public static class Startup
{
  [ScenarioDependencies]
  public static IServiceCollection CreateServices()
  {
    ServiceCollection services = new();
    services.UserWebDriverInitializer();
    services.AddScoped<IBrowserDriver, BrowserDriver>();
    services.AddScoped<IDriverFixture, DriverFixture>();
    services.AddScoped<IHomePage, HomePage>();
    services.AddScoped<ICreatePage, CreatePage>();
    services.AddScoped<IDetailPage, DetailPage>();

    return services;
  }
}
