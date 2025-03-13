using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Domain.Company;
using Domain.Tenant;
using Domain.User;
using Infrastructure.Persistence.Relational.Configuration;

namespace Infrastructure.Persistence.Relational;

public sealed class RelationalDbContext(
  DbContextOptions<RelationalDbContext> options
) : DbContext(options) {
  public DbSet<Tenant> Tenants { get; set; }
  public DbSet<Company> Companies { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    new TenantConfiguration().Configure(modelBuilder.Entity<Tenant>());
    new CompanyConfiguration().Configure(modelBuilder.Entity<Company>());
    new UserConfiguration().Configure(modelBuilder.Entity<User>());

    modelBuilder
      .Model
      .GetEntityTypes()
      .SelectMany(entity => entity.GetProperties())
      .Where(property => property.IsPrimaryKey())
      .ToList()
      .ForEach(property => property.ValueGenerated = ValueGenerated.Never);

    base.OnModelCreating(modelBuilder);
  }
}