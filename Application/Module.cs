using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Mapster;

namespace Application;

public static class Module {
  public static IServiceCollection AddApplication(this IServiceCollection services) {
    services.ConfigureMapper();
    
    return services;
  }

  private static IServiceCollection ConfigureMapper(this IServiceCollection services) {
    var config = TypeAdapterConfig.GlobalSettings;
    config.Scan(Assembly.GetExecutingAssembly());
    services.AddSingleton(config);

    return services;
  }
}