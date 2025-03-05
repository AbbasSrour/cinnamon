using Application.Common.Interfaces;
using Infrastructure.Persistence.Document;
using Infrastructure.Persistence.Relational;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureModule {
  public static IServiceCollection AddInfrastructure(this IServiceCollection services) {
    services.AddCommon();
    return services;
  }

  private static IServiceCollection AddCommon(this IServiceCollection services) {
    services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
    services.AddScoped<IApplicationContext, ApplicationContext>();

    return services;
  }

  private static IServiceCollection AddPersistence(
    this IServiceCollection services,
    ConfigurationManager configuration
  ) {
    services.AddDbContext<RelationalDbContext>(options =>
      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
    );
    services.AddDbContext<DocumentDbContext>(options =>
      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
    );

    // services.AddScoped<IUserRepository, UserRepository>();

    return services;
  }

  private static IServiceCollection AddCrypto(
    this IServiceCollection services,
    ConfigurationManager configuration
  ) {
    services.AddSingleton<IJwtGenerator, JwtGenerator>();
    services.Configure<JwtSettings>(options => configuration.GetSection("Security:Tokens"));

    return services;
  }
}