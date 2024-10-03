using System.Threading;
using Microsoft.Extensions.Caching.Distributed;
using WebUI.Common;

namespace WebUI.IntegrationServices;

public class UserActionInfoService
{
    private readonly CacheService _cacheService;
    private readonly IConfiguration _configuration;
    private readonly double? _expirationTimeInMinutes;

    public UserActionInfoService(CacheService cacheService, IConfiguration configuration)
    {
        _cacheService = cacheService;
        _configuration = configuration;
        _expirationTimeInMinutes = _configuration.GetSection("AppSettings").GetValue<double>("UserActionHandlerExpirationTimeInMinutes");
    }

    public async Task LoginUser(UserActionInfo userInfo)
    {
        var user = await _cacheService.GetAsync<UserActionInfo>("", userInfo.UserId.ToString());
        await _cacheService.AddAsync<UserActionInfo>("", userInfo.UserId.ToString(), _expirationTimeInMinutes, userInfo);

    }
    public async Task DeactivateUser(string userId) 
    {
        //var user= await _cacheService.GetAsync<UserActionInfo>("", userId);
        //if (user != null)
        //{
        //    user.IsActive = false;
        //    await _cacheService.AddAsync<UserActionInfo>("", userId, _expirationTimeInMinutes,user);
        //}

        await _cacheService.DeleteAsync("", userId);
    }

    public async Task UpdateUserRoles(string userId,List<string>userRoles)
    {
        var user = await _cacheService.GetAsync<UserActionInfo>("", userId);
        if (user != null)
        {
            user.Roles = userRoles;
            await _cacheService.AddAsync<UserActionInfo>("", userId, _expirationTimeInMinutes, user);
        }
    }
}
