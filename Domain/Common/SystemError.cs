using FluentResults;

namespace Domain.Common;

public sealed class SystemError : Error {
  public static readonly SystemError None = new(string.Empty, string.Empty, ErrorType.Failure);
  public static readonly SystemError NullValue = new("Error.NullValue", "Null value was provided", ErrorType.Failure);

  private SystemError(string code, string message, ErrorType errorType) {
    Code = code;
    Message = message;
    Type = errorType;
  }

  public string Code { get; }

  public ErrorType Type { get; }

  public static SystemError BadFormat(string code, string message) {
    return new SystemError(code, message, ErrorType.BadFormat);
  }

  public static SystemError Unauthorized(string code, string message) {
    return new SystemError(code, message, ErrorType.Unauthorized);
  }

  public static SystemError Forbidden(string code, string message) {
    return new SystemError(code, message, ErrorType.Forbidden);
  }

  public static SystemError NotFound(string code, string message) {
    return new SystemError(code, message, ErrorType.NotFound);
  }

  public static SystemError Conflict(string code, string message) {
    return new SystemError(code, message, ErrorType.Conflict);
  }

  public static SystemError Validation(string code, string message) {
    return new SystemError(code, message, ErrorType.Validation);
  }

  public static SystemError RateLimit(string code, string message) {
    return new SystemError(code, message, ErrorType.RateLimit);
  }

  public static SystemError Failure(string code, string message) {
    return new SystemError(code, message, ErrorType.Failure);
  }

  // public static implicit operator Result(Error error) {
  //     return Result.Failure(error);
  // }
  //
  // public Result ToResult() {
  //     return Result.Failure(this);
  // }
}

public enum ErrorType {
  BadFormat,
  Unauthorized,
  Forbidden,
  NotFound,
  Conflict,
  Validation,
  RateLimit,
  Failure
}