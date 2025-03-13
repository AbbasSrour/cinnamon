using Domain.Common;
using Domain.User.Entity;
using Domain.User.ValueObject;

namespace Domain.User;

public class User : AggregateRoot<UserId> {
  protected User() : base() { }

  private User(UserId id) : base(id) { }

  public string FirstName { get; private set; } = null!;

  public string LastName { get; private set; } = null!;

  public string Email { get; private set; } = null!;

  public string PhoneNumber { get; private set; } = null!;

  public string Password { get; private set; } = null!;

  public bool IsEmailVerified { get; private set; } = false;

  public bool IsPhoneNumberVerified { get; private set; } = false;

  public bool IsBlocked { get; private set; } = false;

  // private readonly HashSet<Session> _sessions = new();
  // public IReadOnlyList<Session> Sessions => _sessions.ToList();
  
  private ICollection<Session> _sessions = null!;
  public virtual ICollection<Session> Sessions {
      get => _sessions ??= new List<Session>();
      private protected set => _sessions = value;
  }

  public void AddSession(Session session) {
    Sessions.Add(session);
  }

  public void RemoveSession(Session session) {
    Sessions.Remove(session);
  }

  public static User Create(
    string firstName,
    string lastName,
    string email,
    string phoneNumber,
    string password
  ) {
    var user = new User(UserId.Create()) {
      FirstName = firstName,
      LastName = lastName,
      Email = email,
      PhoneNumber = phoneNumber,
      Password = password,
    };

    return user;
  }
}