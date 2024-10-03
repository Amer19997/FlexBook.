using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.IntegrationServices;

public class ProtectedApiBearerTokenHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public ProtectedApiBearerTokenHandler(IHttpContextAccessor httpContextAccessor)
    {
        this.httpContextAccessor = httpContextAccessor;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // request the access token
        var accessToken = httpContextAccessor.HttpContext?.User?.Claims?.FirstOrDefault(c => c.Type == "TOKEN")?.Value;

        // set the bearer token to the outgoing request
        request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

        // Proceed calling the inner handler, that will actually send the request
        // to our protected api
        HttpResponseMessage respnse = await base.SendAsync(request, cancellationToken);

        if (respnse is null || respnse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        {
            throw new UnauthorizedAccessException();
           // return new HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);
        }
        return respnse;
    }

}