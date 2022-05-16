using EATestFramework.Driver;
using EATestFramework.Extensions;
using EATestBDD.Pages;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ProductAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace EATestBDD;

public static class Startup
{
  [ScenarioDependencies]
  public static IServiceCollection CreateServices()
  {
    ServiceCollection services = new();
    services.UserWebDriverInitializer();

    string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new String[] { @"bin\" }, StringSplitOptions.None)[0];
    IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(projectPath)
      .AddJsonFile("appsettings.json")
      .Build();
    string connectionString = configuration.GetConnectionString("DefaultConnection");
    services.AddDbContext<ProductDbContext>(option => option.UseSqlServer(connectionString));

    services.AddScoped<IBrowserDriver, BrowserDriver>();
    services.AddScoped<IDriverFixture, DriverFixture>();
    services.AddScoped<IHomePage, HomePage>();
    services.AddScoped<ICreatePage, CreatePage>();
    services.AddScoped<IDetailPage, DetailPage>();

    return services;
  }
}
