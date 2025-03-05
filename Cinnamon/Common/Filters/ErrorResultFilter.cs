using Cinnamon.Common.Dto;
using Domain.Common;
using FluentResults;
using FluentResults.Extensions.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Cinnamon.Common.Filters;

public class ErrorResultFilter : IAsyncResultFilter {
  private readonly ProblemDetailsFactory _problemDetailsFactory;

  public ErrorResultFilter(ProblemDetailsFactory problemDetailsFactory) {
    _problemDetailsFactory = problemDetailsFactory;
  }

  public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next) {
    var result = context.Result is ObjectResult { Value: IError error } ? [error] :
      context.Result is ObjectResult { Value: IEnumerable<IError> errors } ? errors.ToList() :
      null;
    if (result != null) context.Result = ToActionResult(result, context);

    await next();
  }

  private ActionResult ToActionResult(List<IError> errors, ResultExecutingContext context) {
    if (errors.Count == 0)
      return new ObjectResult(_problemDetailsFactory.CreateProblemDetails(
        context.HttpContext,
        StatusCodes.Status500InternalServerError
      ));

    var firstError = errors.First();
    var (statusCode, title) = GetStatusCodeAndMessage(firstError);

    var extensions = new Dictionary<string, object?>();
    if (firstError is SystemError error) extensions.Add("code", error.Code);
    extensions.Add("reasons", firstError.Reasons.Select(SerializeErrors));
    extensions.Add("errors", errors.Select(SerializeErrors));

    var problemDetails = _problemDetailsFactory.CreateProblemDetails(
      context.HttpContext,
      statusCode,
      title,
      detail: errors.First().Message
    );
    problemDetails.Extensions = extensions;

    return new ObjectResult(problemDetails) { StatusCode = problemDetails.Status };
  }

  private (int, string) GetStatusCodeAndMessage(IError? error) {
    if (error is SystemError systemError)
      return systemError.Type switch {
        ErrorType.BadFormat => (StatusCodes.Status400BadRequest, "Bad Request"),
        ErrorType.Unauthorized => (StatusCodes.Status401Unauthorized, "Unauthorized"),
        ErrorType.Forbidden => (StatusCodes.Status403Forbidden, "Forbidden"),
        ErrorType.NotFound => (StatusCodes.Status404NotFound, "Not Found"),
        ErrorType.Conflict => (StatusCodes.Status409Conflict, "Conflict"),
        ErrorType.Validation => (StatusCodes.Status422UnprocessableEntity, "Unprocessable Entity"),
        ErrorType.RateLimit => (StatusCodes.Status429TooManyRequests, "Too Many Requests"),
        ErrorType.Failure => (StatusCodes.Status500InternalServerError, "Internal Server Error"),
        _ => throw new ArgumentException()
      };

    return (StatusCodes.Status500InternalServerError, "Internal Server Error");
  }

  private SystemErrorDto SerializeErrors(IError error) {
    var code = error is SystemError e ? e.Code : null;
    var reasons = error.Reasons.Select(SerializeErrors).Cast<IErrorDto>().ToList();
    return new SystemErrorDto(error.Message, code, reasons);
  }
}