using Domain.User.ValueObject;

namespace Domain.User.Entity;

public class Session : Common.Entity<SessionId> {
  protected Session() : base() { }

  private Session(SessionId id) : base(id) { }

  public bool IsClosed { get; private set; } = false;

  public UserAgent UserAgent { get; private set; } = null!;

  public DateTime ValidUntil { get; private set; } = default!;

  public DateTime? ClosedAt { get; private set; }

  public DateTime? LastActivityAt { get; private set; }


  public static Session Create(SessionId id, string token, UserAgent agent, DateTime validUntil) {
    var session = new Session(id) {
      UserAgent = agent,
      ValidUntil = validUntil,
      ClosedAt = null,
      LastActivityAt = null,
    };

    return session;
  }
}