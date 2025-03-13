using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Relational.Configuration;

public abstract class BaseEntityConfiguration<TEntity, TId>
  where TEntity : Entity<TId>
  where TId : notnull {
  public virtual void Configure(EntityTypeBuilder<TEntity> builder) {
    // Configure CreatedAt property
    builder.Property(e => e.CreatedAt)
      .HasColumnName("created_at")
      .IsRequired()
      .ValueGeneratedOnAdd();

    // Configure UpdatedAt property
    builder.Property(e => e.UpdatedAt)
      .HasColumnName("updated_at")
      .IsRequired()
      .ValueGeneratedOnUpdate();

    // Configure IsDeleted property
    builder.Property(e => e.IsDeleted)
      .HasColumnName("is_deleted")
      .IsRequired()
      .HasDefaultValue(false);
  }
}