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

namespace FlexBook.Application.Users.Commands.PortalSignInCommand;
public class PortalSignInHandler : IRequestHandler<PortalSignInCommand, TResponse<AuthResponseDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;
    private readonly IResourceService _resourceService;
    private readonly AppSettings _appSettings;
    public PortalSignInHandler(IUnitOfWork unitOfWork,
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

    public async Task<TResponse<AuthResponseDto>> Handle(PortalSignInCommand request, CancellationToken cancellationToken)
    {
        var user = await _unitOfWork.Users.GetUserByEmailOrNameAsync(request.Email);
        var hashedPassword = await _accountService.GetHashString(request.Password);

        if (user == null)
        {
            //_logger.LogWarning("User not found with email or name: {EmailOrName}", request.EmailOrName);
            return TResponse<AuthResponseDto>.Failure(new[] { _resourceService.GetError("User not found") });
        }

        // Ensure user is either Student or Instructor
        if (user.UserType != UserTypeEnum.Student && user.UserType != UserTypeEnum.Instructor)
        {
            //_logger.LogWarning("Unauthorized login attempt by non-portal user: {EmailOrName}", request.EmailOrName);
            return TResponse<AuthResponseDto>.Failure(new[] { _resourceService.GetError("Unauthorized access") });
        }

        if (user.Password != hashedPassword)
        {
            //_logger.LogWarning("Invalid password for user: {EmailOrName}", request.EmailOrName);
            return TResponse<AuthResponseDto>.Failure(new[] { _resourceService.GetError("Invalid credentials") });
        }

        var isInstructor = user.UserType == UserTypeEnum.Instructor;

        // Generate JWT token with 'isInstructor' flag
        var token = _tokenService.GeneratePortalToken(user, isInstructor);

        var profile = new UserProfileDto
        {
            UserId = user.Id,
            Name = $"{user.FirstName} {user.LastName}",
            Email = user.Email,
            UserType = user.UserType.ToString()
        };

        return TResponse<AuthResponseDto>.Success(new AuthResponseDto
        {
            Token = token,
            UserProfile = profile
        });
    }
}
