using Application.Common.Interfaces;
using Asp.Versioning;
using Cinnamon.Common.Config;
using Cinnamon.Common.Filters;
using Cinnamon.Common.Handlers;
using Cinnamon.Common.Services;
using FluentResults.Extensions.AspNetCore;

namespace Cinnamon;

public static class WebModule {
  public static IServiceCollection AddWeb(this IServiceCollection services) {
    services.AddControllers();
    services.AddHttpContextAccessor();
    services.AddOpenApi();

    services.AddApiVersioning(options => {
      options.DefaultApiVersion = new ApiVersion(1);
      options.ReportApiVersions = true;
      options.AssumeDefaultVersionWhenUnspecified = true;
      options.ApiVersionReader = ApiVersionReader.Combine(
        new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("X-Api-Version"),
        new QueryStringApiVersionReader("apiVersion")
      );
    });

    services.AddScoped<TenantExistsFilter>();

    services.ConfigureResponseHandling();
    services.ConfigureErrorHandling();

    services.AddTransient<ILanguageCodeProvider, LanguageCodeProvider>();
    services.AddTransient<ITenantIdProvider, TenantIdProvider>();

    return services;
  }

  private static IServiceCollection ConfigureResponseHandling(this IServiceCollection services) {
    AspNetCoreResult.Setup(
      config => config.DefaultProfile = new ResultEndpointProfile()
    );

    return services;
  }

  private static IServiceCollection ConfigureErrorHandling(this IServiceCollection services) {
    services.AddScoped<ErrorResultFilter>();
    services
      .AddProblemDetails(options =>
        options.CustomizeProblemDetails = ctx => {
          ctx.ProblemDetails.Extensions.Add("instance",
            $"{ctx.HttpContext.Request.Method} {ctx.HttpContext.Request.Path}");
        });
    services.AddExceptionHandler<ServerErrorExceptionHandler>();

    return services;
  }
}