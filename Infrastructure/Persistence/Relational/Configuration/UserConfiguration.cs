using Domain.User;
using Domain.User.Entity;
using Domain.User.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;

namespace Infrastructure.Persistence.Relational.Configuration;

public class UserConfiguration : BaseEntityConfiguration<User, UserId> {
  public override void Configure(EntityTypeBuilder<User> builder) {
    base.Configure(builder);
    ConfigureTable(builder);
    ConfigureSessions(builder);
  }

  private void ConfigureTable(EntityTypeBuilder<User> builder) {
    builder.ToTable("user");

    // ID 
    builder.HasKey(user => user.Id);

    builder
      .Property(user => user.Id)
      .HasColumnName("id")
      .IsRequired()
      .HasConversion(
        userId => userId.Value,
        id => UserId.Create(id)
      );

    // First Name
    builder
      .Property(user => user.FirstName)
      .HasColumnName("first_name")
      .IsRequired()
      .HasMaxLength(100);

    // Last Name
    builder
      .Property(user => user.LastName)
      .HasColumnName("last_name")
      .IsRequired()
      .HasMaxLength(100);

    // Email
    builder
      .Property(user => user.Email)
      .HasColumnName("email")
      .IsRequired()
      .HasMaxLength(480);

    builder
      .HasIndex(user => user.Email)
      .IsUnique();

    // Phone Number
    builder
      .Property(user => user.PhoneNumber)
      .HasColumnName("phone_number")
      .IsRequired()
      .HasMaxLength(100);

    builder
      .HasIndex(user => user.PhoneNumber)
      .IsUnique();

    // Password
    builder
      .Property(user => user.Password)
      .HasColumnName("password")
      .IsRequired();

    // IsEmailVerified
    builder
      .Property(user => user.IsEmailVerified)
      .HasColumnName("is_email_verified")
      .IsRequired()
      .HasDefaultValue(false);

    // IsPhoneNumberVerified
    builder
      .Property(user => user.IsPhoneNumberVerified)
      .HasColumnName("is_phone_number_verified")
      .IsRequired()
      .HasDefaultValue(false);

    // IsBlocked
    builder
      .Property(user => user.IsBlocked)
      .HasColumnName("is_blocked")
      .IsRequired()
      .HasDefaultValue(false);
  }

  private void ConfigureSessions(EntityTypeBuilder<User> builder) {
    builder.OwnsMany<Session>(user => user.Sessions, sessionBuilder => {
      sessionBuilder.ToTable("user_session");
      sessionBuilder.WithOwner().HasForeignKey("user_id");

      // Id
      sessionBuilder.HasKey(session => session.Id);

      sessionBuilder
        .Property(session => session.Id)
        .HasColumnName("id")
        .IsRequired()
        .HasConversion(
          sessionId => sessionId.Value,
          id => SessionId.Create(id)
        );
      
      // IsClosed
      sessionBuilder
        .Property(session => session.IsClosed)
        .HasColumnName("is_closed")
        .IsRequired()
        .HasDefaultValue(false);

      // User Agent
      sessionBuilder
        .Property(session => session.UserAgent)
        .HasColumnName("user_agent")
        .IsRequired()
        .HasMaxLength(1000)
        .HasConversion(
          agent => agent.Value,
          value => UserAgent.Create(value)
        );

      // ValidUntil
      sessionBuilder
        .Property(session => session.ValidUntil)
        .HasColumnName("valid_until")
        .IsRequired();

      // ClosedAt
      sessionBuilder
        .Property(session => session.ClosedAt)
        .HasColumnName("closed_at")
        .IsRequired(false);

      // LastActivityAt
      sessionBuilder
        .Property(session => session.LastActivityAt)
        .HasColumnName("last_activity_at")
        .IsRequired(false);
    });
  }
}