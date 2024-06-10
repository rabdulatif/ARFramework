using System.Net;
using AR.AspNetCore.Logics.CustomExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AR.AspNetCore.Logics.Middlewares;

public class ErrorHandlingMiddleware
{
    /// <summary>
    /// </summary>
    private readonly RequestDelegate next;

    /// <summary>
    /// </summary>
    /// <param name="next"></param>
    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    /// <returns></returns>
    public async Task Invoke(HttpContext context, ILogger<ErrorHandlingMiddleware> logger)
    {
        try
        {
            await next(context);
        }
        catch(UnauthorizedException ex)
        {
            await WriteExceptionAsync(context, logger, ex, HttpStatusCode.Unauthorized);
        }
        catch (HttpRequestException ex)
        {
            await WriteExceptionAsync(context, logger, ex, HttpStatusCode.Forbidden);
        }
        catch (Exception ex)
        {
            await WriteExceptionAsync(context, logger, ex, HttpStatusCode.InternalServerError);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="logger"></param>
    /// <param name="ex"></param>
    /// <param name="code"></param>
    /// <returns></returns>
    private Task WriteExceptionAsync(HttpContext context, ILogger<ErrorHandlingMiddleware> logger, Exception ex, HttpStatusCode code)
    {
        var result = JsonConvert.SerializeObject(new { error = ex.Message, innerException = ex.InnerException?.Message });
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)code;
        return context.Response.WriteAsync(result);
    }
}