using Domain.Common;
using Domain.Tenant.ValueObject;

namespace Domain.Tenant;

public class Tenant : AggregateRoot<TenantId> {
  protected Tenant() : base() {}
  
  private Tenant(TenantId id) : base(id) { }

  public string Name { get; private set; } = null!;

  public static Tenant Create(string name) {
    var tenant = new Tenant(TenantId.Create()) {
      Name = name
    };

    return tenant;
  }
}