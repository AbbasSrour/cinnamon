namespace Domain.User.ValueObject;

public class UserId : Common.ValueObject {
    private UserId(Guid userId) {
        Value = userId;
    }

    public Guid Value { get; }

    public static UserId Create(Guid userId = new()) {
        return new UserId(userId);
    }

    public static UserId Create(string userId) {
        return new UserId(Guid.Parse(userId));
    }

    protected override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}