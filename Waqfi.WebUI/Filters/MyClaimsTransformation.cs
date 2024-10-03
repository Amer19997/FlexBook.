using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Security.Principal;
using WebUI.Common;
using WebUI.IntegrationServices;

namespace WebUI.Filters;

public class MyClaimsTransformation : IClaimsTransformation
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly CacheService _cacheService;

    public MyClaimsTransformation(IHttpContextAccessor httpContextAccessor, CacheService cacheService)
    {
        this.httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _cacheService = cacheService;
    }
    public  Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var userId = principal?.Identity?.Name ?? "";
        if(userId == null) { 
            return Task.FromResult(principal); 
        }

         UserActionInfo? userActionInfo = (_cacheService.GetAsync<UserActionInfo>("", userId).Result) ?? new UserActionInfo();
        if(userActionInfo.IsActive == false) 
        {
            var identity2 = principal.Identity as ClaimsIdentity;
            principal.Claims.ToList().ForEach(_ => identity2.RemoveClaim(_));
            Task.FromResult(httpContextAccessor.HttpContext.SignOutAsync());

        }
        if (userActionInfo.Roles != null)
        {
            var roleClaims = principal.Claims.Where(_ => _.Type == ClaimTypes.Role);
            List<string> userContextRoles = roleClaims
                .Select(_ => _.Value.ToLower()).ToList();

            if (userActionInfo.Roles.Select(_ => _.ToLower()).Except(userContextRoles).Any() || userContextRoles.Except(userActionInfo.Roles.Select(_ => _.ToLower())).Any())
            {
                var identity = principal.Identity as ClaimsIdentity;

                roleClaims.ToList().ForEach(_ => identity.RemoveClaim(_));
            
                var claims=userActionInfo.Roles.Select(x => new Claim(ClaimTypes.Role, x));


                principal.AddIdentity(new ClaimsIdentity(claims, "AuthCooKie"));

            }
        }
        return Task.FromResult(principal);
    }
}
