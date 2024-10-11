using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Models;
using FlexBook.Domain.Entities.Catalog.Dtos;
using FlexBook.Domain.Enums;
using FlexBook.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using FlexBook.Application.Common.Helpers;
using Microsoft.Extensions.Options;
using FlexBook.Domain.Repositories;
using FlexBook.Application.Users.Commands.SignUpCommand;
using FlexBook.Domain.Entities;

namespace FlexBook.Application.Features.Admin.Commnds.DashBoardLoginCommand;
public class DashboardSignInHandler : IRequestHandler<DashboardSignInCommand, TResponse<AuthResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;
    private readonly IResourceService _resourceService;
    private readonly AppSettings _appSettings;
    
    public DashboardSignInHandler(IUnitOfWork unitOfWork,
        ICacheService cacheService,
        IAccountService accountService,
        ITokenService tokenService,
        IOptions<AppSettings> appSettings,
        IResourceService resourceService,
        IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;
        _accountService = accountService;
        _tokenService = tokenService;
        _appSettings = appSettings.Value;
        _resourceService = resourceService;
    }

    public async Task<TResponse<AuthResponseDto>> Handle(DashboardSignInCommand request, CancellationToken cancellationToken)
    {
        // Find user by email or name
   
        // Use the new method to fetch the user
        var user = await _unitOfWork.Users.GetUserByEmailOrNameAsync(request.EmailOrName);

        if (user == null)
        {
            return TResponse<AuthResponseDto>.Failure(new[] { _resourceService.GetError("User not found") });
 
        }
        // Ensure the user is a DashboardUser
        if (user.UserType != UserTypeEnum.DashboardUser)
        {
            //_logger.LogWarning("Unauthorized login attempt by non-dashboard user: {EmailOrName}", request.EmailOrName);
            return TResponse<AuthResponseDto>.Failure(new[] { _resourceService.GetError("Unauthorized access") });

        }

        // Verify password
        var hashedPassword = await _accountService.GetHashString(request.Password);

        if ( user.Password != hashedPassword)
            
        {
            //_logger.LogWarning("Invalid password for user: {EmailOrName}", request.EmailOrName);
            return TResponse<AuthResponseDto>.Failure(new[] { _resourceService.GetError("Invalid credentials") });

        }
        var roleid = user.RoleId;
        var role = await _unitOfWork.RoleRepository.GetByIdAsync(user.RoleId);
        // Get the user's role
        var roleName =role.RoleName ;

        // Generate JWT token
        var token = _tokenService.GenerateDashboardToken(user, roleName);

        // Return the authentication response
        var dashboardProfile = new UserProfileDto
        {
            UserId = user.Id,
            Name = $"{user.FirstName} {user.LastName}",
            Email = user.Email,
            UserType = user.UserType.ToString() // Should be DashboardUser
        };

        return TResponse<AuthResponseDto>.Success(new AuthResponseDto
        {
            Token = token,
            UserProfile = dashboardProfile
        });
    }
}
