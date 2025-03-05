namespace Domain.Common;

public abstract class Entity<TId> : IEquatable<Entity<TId>> where TId : notnull {
    protected Entity(TId id) {
        Id = id;
    }

    public TId Id { get; }

    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public bool IsDeleted { get; private set; } = false;

    public bool Equals(Entity<TId>? other) {
        return Equals((object?)other);
    }

    public override bool Equals(object? obj) {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }

    public static bool operator ==(Entity<TId> left, Entity<TId> right) {
        return Equals(left, right);
    }

    public static bool operator !=(Entity<TId> left, Entity<TId> right) {
        return !Equals(left, right);
    }
}