using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace OpenMenu.WebAPI.Middleware;

public class GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        logger.LogError(exception, "Unhandled exception: {Message}", exception.Message);

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        httpContext.Response.ContentType = "application/json";

        var response = new
        {
            IsSuccess = false,
            Data = (object?)null,
            ErrorMessage = "Beklenmeyen bir hata oluştu."
        };

        await httpContext.Response.WriteAsync(
            JsonSerializer.Serialize(response),
            cancellationToken);

        return true;
    }
}
