﻿using Microsoft.Extensions.DependencyInjection;

namespace Domain;

public static class Module {
  public static IServiceCollection AddDomain(this IServiceCollection services) {
    return services;
  }
}