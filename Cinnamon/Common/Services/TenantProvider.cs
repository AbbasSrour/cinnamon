using Application.Common.Interfaces;
using Cinnamon.Common.Exceptions;
using Domain.Tenant.ValueObject;

namespace Cinnamon.Common.Services;

public class TenantIdProvider : ITenantIdProvider {
  private readonly IHttpContextAccessor _httpContextAccessor;

  public TenantIdProvider(IHttpContextAccessor httpContextAccessor) {
    _httpContextAccessor = httpContextAccessor;
  }

  public TenantId? GetTenantId() {
    var tenantHeader = _httpContextAccessor.HttpContext?.Request.Headers["X-Tenant-Id"];
    if (tenantHeader is null) return null;
    try {
      return TenantId.Create(tenantHeader!);
    }
    catch (FormatException) {
      throw new InvalidTenantIdException();
    }
  }
}