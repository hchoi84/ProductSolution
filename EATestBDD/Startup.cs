using EATestFramework.Driver;
using EATestFramework.Extensions;
using EATestBDD.Pages;
using Microsoft.Extensions.DependencyInjection;

namespace EATestBDD
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.UserWebDriverInitializer();
      services.AddScoped<IBrowserDriver, BrowserDriver>();
      services.AddScoped<IDriverFixture, DriverFixture>();
      services.AddScoped<IHomePage, HomePage>();
      services.AddScoped<ICreatePage, CreatePage>();
      services.AddScoped<IDetailPage, DetailPage>();
    }
  }
}
