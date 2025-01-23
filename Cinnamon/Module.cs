namespace Cinnamon;

public static class WebModule {
  public static IServiceCollection AddWeb(this IServiceCollection services) {
    services.AddControllers();
    services.AddOpenApi();
    
    return services;
  }
}