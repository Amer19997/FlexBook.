using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Domain.Entities;
using FlexBook.Domain.Repositories;
using FlexBook.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace FlexBook.Application.Common;
public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    private readonly ICurrentUserService _currentUserService;
    private readonly RoleRepositoryInterface _roleRepository;

    private readonly IUserRepository _userrepo;

    public PermissionHandler(ICurrentUserService currentUserService, RoleRepositoryInterface roleRepository,IUserRepository userrepo)
    {
        _currentUserService = currentUserService;
        _roleRepository = roleRepository;
        _userrepo = userrepo;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var userId = _currentUserService.UserId;
        CancellationToken cancellation = CancellationToken.None;
        // Convert the string userId to a Guid
        if (Guid.TryParse(userId, out var userGuid))
        {
           
            var user = _userrepo.FindById(userGuid, cancellation);
            var roleid = user.Result?.RoleId;
            var userRole = await _roleRepository.GetByIdAsync(roleid);

            if (userRole.Permissions.Any(rp => rp.PermissionName == requirement.Permission))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
        else
        {
            // If the userId is not a valid Guid, fail the requirement
            context.Fail();
        }
    }
}