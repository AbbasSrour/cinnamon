using Domain.Tenant.ValueObject;

namespace Application.Common.Interfaces;

public interface ITenantIdProvider {
    TenantId? GetTenantId();
}