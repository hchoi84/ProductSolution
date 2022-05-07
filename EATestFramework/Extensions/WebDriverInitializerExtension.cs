using EATestFramework.Settings;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EATestFramework.Extensions
{
  public static class WebDriverInitializerExtension
  {
    public static IServiceCollection UserWebDriverInitializer(this IServiceCollection services)
    {
      services.AddSingleton(ReadConfig);

      return services;
    }

    private static TestSettings ReadConfig()
    {
      string location = Assembly.GetExecutingAssembly().Location;
      string? directory = Path.GetDirectoryName(location);
      string? configFile = File.ReadAllText(directory + "/appsettings.json");

      #region for enum property
      JsonSerializerOptions jsonSerializerOptions = new()
      {
        PropertyNameCaseInsensitive = true
      };

      jsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
      #endregion

      TestSettings? testSettings = JsonSerializer.Deserialize<TestSettings>(configFile, jsonSerializerOptions);
      return testSettings ?? new TestSettings();
    }
  }
}
