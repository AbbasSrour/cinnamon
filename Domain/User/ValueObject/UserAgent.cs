namespace Domain.User.ValueObject;

public class UserAgent : Common.ValueObject {
    private UserAgent(string value) {
        Value = value;
    }

    public string Value { get; }

    public static UserAgent Create(string value) {
        return new UserAgent(value);
    }

    protected override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}