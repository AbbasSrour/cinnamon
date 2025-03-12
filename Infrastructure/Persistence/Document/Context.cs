using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Document;

public sealed class DocumentDbContext(
    DbContextOptions<DocumentDbContext> options
) : DbContext(options) {
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(DocumentDbContext).Assembly,
            QueryConfigurationFilter
        );
        base.OnModelCreating(modelBuilder);
    }

    private static bool QueryConfigurationFilter(Type type) {
        return type.FullName?.Contains("Document.Configuration") ?? false;
    }
}