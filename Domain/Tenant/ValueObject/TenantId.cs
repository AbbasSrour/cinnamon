namespace Domain.Tenant.ValueObject;

public class TenantId : Common.ValueObject {
    private TenantId(Guid tenantId) {
        Value = tenantId;
    }

    public Guid Value { get; }

    public static TenantId Create(Guid tenantId = new()) {
        return new TenantId(tenantId);
    }

    public static TenantId Create(string tenantId) {
        return new TenantId(Guid.Parse(tenantId));
    }

    protected override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}