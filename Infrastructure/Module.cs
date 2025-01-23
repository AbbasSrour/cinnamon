using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureModule {
  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    return services;
  }
}