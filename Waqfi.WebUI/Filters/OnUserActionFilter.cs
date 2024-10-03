using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using WebUI.Common;
using WebUI.IntegrationServices;

namespace WebUI.Filters;

public class OnUserActionFilter : IResultFilter
{
    private readonly CacheService _cacheService;

    public OnUserActionFilter(CacheService cacheService)
    {
        _cacheService = cacheService;
    }


    public void OnResultExecuted(ResultExecutedContext context)
    {
       
    }

    public void OnResultExecuting(ResultExecutingContext _context)
    {
        var context = _context.HttpContext;
        if (context.Request.Path.Value !=null && !context.Request.Path.Value.ToLower().Contains("admin") && context.Request.Path.Value.ToLower()!= "/linkexpired")
        {
            var userId = context.User.Identity?.Name ?? "";

            UserActionInfo? userActionInfo = (_cacheService.GetAsync<UserActionInfo>("", userId).Result) ?? new UserActionInfo();

            if (!userActionInfo.IsActive)
            {
                throw new UnauthorizedAccessException();
            }

            List<string> userContextRoles = context.User.Claims.Where(_ => _.Type == ClaimTypes.Role)
                .Select(_ => _.Value.ToLower()).ToList();
                
             
            if (userActionInfo.Roles.Select(_ => _.ToLower()).Except(userContextRoles).Any() || userContextRoles.Except(userActionInfo.Roles.Select(_ => _.ToLower())).Any())
            {
                throw new UnauthorizedAccessException();
                //var claims = new List<Claim>()
                //{
                //    new Claim("Name",userActionInfo.Name),
                //    new Claim(ClaimTypes.Name,userActionInfo.UserId.ToString()),
                //    new Claim("TOKEN",userActionInfo.Token),
                //};

                //claims.AddRange(userActionInfo.Roles.Select(x => new Claim(ClaimTypes.Role, x)));

                //var identity = new ClaimsIdentity(claims, "AuthCooKie");

                //ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
                //context.SignInAsync("AuthCooKie", claimsPrincipal).GetAwaiter();
                //context.Response.Redirect(context.Request.Path.Value);
            }
        }
    }
}
