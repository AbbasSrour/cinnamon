using Domain.Common;

namespace Cinnamon.Common.Exceptions;

public class InvalidTenantIdException : Exception, ISystemException {
  public InvalidTenantIdException() : base("Invalid Tenant Id") { }

  public InvalidTenantIdException(string message)
    : base(message) { }

  public InvalidTenantIdException(string message, Exception innerException)
    : base(message, innerException) { }

  public string Code => "error.system.invalidTenantId";
}