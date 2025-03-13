using Domain.Company;
using Domain.Company.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Relational.Configuration;

public class CompanyConfiguration : BaseEntityConfiguration<Company, CompanyId> {
  public override void Configure(EntityTypeBuilder<Company> builder) {
    base.Configure(builder);
    ConfigureTable(builder);
  }

  private void ConfigureTable(EntityTypeBuilder<Company> builder) {
    builder.ToTable("companies");

    // ID
    builder.HasKey(company => company.Id);
    builder
      .Property(company => company.Id)
      .HasColumnName("id")
      .IsRequired()
      .HasConversion(
        companyId => companyId.Value,
        id => CompanyId.Create(id)
      );
    
    // Name
    builder.Property(company => company.Name)
      .HasColumnName("name")
      .IsRequired();
    
    // Phone
    builder.Property(company => company.Phone)
      .HasColumnName("phone")
      .IsRequired();
  }
}