using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebUI.Filters;

public class ErrorWrappingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorWrappingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (UnauthorizedAccessException ex)
        {
           //  context.Response.Redirect("/Admin/Login");

            //context.Response.StatusCode = 500;
        }

        if (!context.Response.HasStarted)
        {
            context.Response.ContentType = "application/json";

         

            await context.Response.WriteAsync("");
        }
    }
}
