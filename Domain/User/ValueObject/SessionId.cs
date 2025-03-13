namespace Domain.User.ValueObject;

public class SessionId : Common.ValueObject {
  private SessionId(Guid sessionId) {
    Value = sessionId;
  }

  public Guid Value { get; }

  public static SessionId Create(Guid sessionId = new()) {
    return new SessionId(sessionId);
  }

  public static SessionId Create(string sessionId) {
    return new SessionId(Guid.Parse(sessionId));
  }

  protected override IEnumerable<object> GetEqualityComponents() {
    yield return Value;
  }
}