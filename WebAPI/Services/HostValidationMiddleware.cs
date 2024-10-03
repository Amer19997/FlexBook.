using System.Linq;
using System.Threading.Tasks;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using RestSharp;
using FlexBook.Application.Common.Helpers;

public class HostValidationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly HostNamesConfiguration _hostNamesConfiguration;
    private readonly AppSettings _appsetting;

    public HostValidationMiddleware(RequestDelegate next, HostNamesConfiguration hostNamesConfiguration, IOptions<AppSettings> appsetting)
    {
        _next = next;
        _hostNamesConfiguration = hostNamesConfiguration;
        _appsetting = appsetting.Value;
    }

    public async Task InvokeAsync(HttpContext context) 
    {
        if (_appsetting.HostValidation)
        {
            _hostNamesConfiguration.Hosts = _appsetting.AllowedHostsTest.Split(',').ToArray();
            var requestHost = context.Request.Host.Host;

            if (!_hostNamesConfiguration.Hosts.Contains(requestHost))
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid hostname");
                context.Abort();
                return;
            }
        }
        await _next(context);
    }
}

public class HostNamesConfiguration
{
    public string[] Hosts { get; set; }
}