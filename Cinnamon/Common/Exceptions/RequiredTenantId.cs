using Domain.Common;

namespace Cinnamon.Common.Exceptions;

public class TenantIdRequiredException : Exception, ISystemException {
  public TenantIdRequiredException() : base("Tenant Id is required") { }

  public TenantIdRequiredException(string message)
    : base(message) { }

  public TenantIdRequiredException(string message, Exception innerException)
    : base(message, innerException) { }

  public string Code => "error.system.tenantIdRequired";
}