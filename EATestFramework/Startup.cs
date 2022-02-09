using EATestFramework.Driver;
using Microsoft.Extensions.DependencyInjection;

namespace EATestFramework
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.UserWebDriverInitializer(BrowserType.Edge);
      services.AddScoped<IBrowserDriver, BrowserDriver>();
      services.AddScoped<IDriverFixture, DriverFixture>();
    }
  }
}
