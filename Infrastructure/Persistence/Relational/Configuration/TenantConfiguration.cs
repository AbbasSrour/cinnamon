using Domain.Tenant;
using Domain.Tenant.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Relational.Configuration;

public class TenantConfiguration : BaseEntityConfiguration<Tenant, TenantId> {
  public override void Configure(EntityTypeBuilder<Tenant> builder) {
    base.Configure(builder);
    ConfigureTable(builder);
  }

  private void ConfigureTable(EntityTypeBuilder<Tenant> builder) {
    builder.ToTable("tenants");

    // ID
    builder.HasKey(tenant => tenant.Id);
    builder
      .Property(tenant => tenant.Id)
      .HasColumnName("id")
      .IsRequired()
      .HasConversion(
        tenantId => tenantId.Value,
        id => TenantId.Create(id)
      );

    // Name
    builder.Property(tenant => tenant.Name)
      .HasColumnName("name")
      .IsRequired();
  }
}