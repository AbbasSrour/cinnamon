using Domain.Tenant;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Document.Configuration;

public class TenantConfiguration {
  public TenantConfiguration(EntityTypeBuilder<Tenant> builder) {
    ConfigureTable(builder);
  }

  private void ConfigureTable(EntityTypeBuilder<Tenant> builder) {
  }
}