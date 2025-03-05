using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Cinnamon.Common.Handlers;

public class ServerErrorExceptionHandler : IExceptionHandler {
    private readonly IProblemDetailsService _problemDetailsService;

    public ServerErrorExceptionHandler(IProblemDetailsService problemDetailsService) {
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    ) {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext {
            HttpContext = httpContext,
            ProblemDetails = {
                Title = "Internal Server Error",
                Detail = exception.Message,
                Type = exception.GetType().Name
            },
            Exception = exception
        });
    }
}