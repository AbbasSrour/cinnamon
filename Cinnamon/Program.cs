using Domain;
using Application;
using Infrastructure;
using Scalar.AspNetCore;

namespace Cinnamon;

public static class Program {
  public static void Main(string[] args) {
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddDomain();
    builder.Services.AddApplication();
    builder.Services.AddWeb();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment()) {
      app.MapOpenApi();
      app.MapScalarApiReference();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
  }
}