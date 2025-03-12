using Domain.Company;
using Domain.Tenant;
using Infrastructure.Persistence.Relational.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Persistence.Relational;

public sealed class RelationalDbContext(
  DbContextOptions<RelationalDbContext> options
) : DbContext(options) {
  public DbSet<Tenant> Tenants { get; set; }
  public DbSet<Company> Companies { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder) {
    new TenantConfiguration().Configure(modelBuilder.Entity<Tenant>());
    new CompanyConfiguration().Configure(modelBuilder.Entity<Company>());

    modelBuilder
      .Model
      .GetEntityTypes()
      .SelectMany(entity => entity.GetProperties())
      .Where(property => property.IsPrimaryKey())
      .ToList()
      .ForEach(property => property.ValueGenerated = ValueGenerated.Never);

    modelBuilder
      .Model
      .GetEntityTypes()
      .SelectMany(entity => entity.GetProperties())
      .Where(property => property.Name == "CreatedAt")
      .ToList()
      .ForEach(property => property.SetColumnName("created_at"));
    
    modelBuilder
      .Model
      .GetEntityTypes()
      .SelectMany(entity => entity.GetProperties())
      .Where(property => property.Name == "UpdatedAt")
      .ToList()
      .ForEach(property => property.SetColumnName("updated_at"));
    
    modelBuilder
      .Model
      .GetEntityTypes()
      .SelectMany(entity => entity.GetProperties())
      .Where(property => property.Name == "IsDeleted")
      .ToList()
      .ForEach(property => property.SetColumnName("is_deleted"));

    base.OnModelCreating(modelBuilder);
  }
}