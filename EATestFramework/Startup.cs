﻿using EATestFramework.Driver;
using EATestFramework.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace EATestFramework
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.UserWebDriverInitializer(BrowserTypeEnum.Edge);
      services.AddScoped<IBrowserDriver, BrowserDriver>();
      services.AddScoped<IDriverFixture, DriverFixture>();
    }
  }
}
