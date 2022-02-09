using Microsoft.Extensions.DependencyInjection;
using SeleniumXUnitBasic.Driver;

namespace SeleniumXUnitBasic
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
