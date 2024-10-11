using System.Security.Claims;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.WebAPI.Services;
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid GetUserRoleId()
    {
        var roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.Role);
        return Guid.TryParse(roleClaim, out var roleId) ? roleId : Guid.Empty;
    }
    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public string? profieId => _httpContextAccessor.HttpContext?.User?.FindFirstValue("ProfileId");
}
