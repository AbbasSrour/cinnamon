using Application.Common.Constants;
using Domain.Tenant.ValueObject;

namespace Application.Common.Interfaces;

public interface IApplicationContext {
    TenantId? TenantId { get; }
    LanguageCode LanguageCode { get; }
}