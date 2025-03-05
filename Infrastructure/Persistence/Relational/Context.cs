using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Relational;

public sealed class RelationalDbContext(
  DbContextOptions<RelationalDbContext> options
) : DbContext(options) {
  // public DbSet<UserAggregate> Users { get; set; }
  // public DbSet<CompanyAggregate> Companies { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    modelBuilder.ApplyConfigurationsFromAssembly(
      typeof(RelationalDbContext).Assembly,
      CommandConfigurationFilter
    );
    base.OnModelCreating(modelBuilder);
  }

  private static bool CommandConfigurationFilter(Type type) {
    return type.FullName?.Contains("Relational.Configuration") ?? false;
  }
}