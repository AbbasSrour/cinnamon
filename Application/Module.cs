using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class Module {
  public static IServiceCollection AddApplication(this IServiceCollection services) {
    return services;
  }
}