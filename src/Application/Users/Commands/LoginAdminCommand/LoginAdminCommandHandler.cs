using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Common.Models.Dtos;
using FlexBook.Domain;
using MediatR;
using Microsoft.Extensions.Options;

namespace FlexBook.Application.Users.Commands.LoginAdminCommand;
public class LoginAdminCommandHandler : IRequestHandler<LoginAdminCommand, TResponse<LoginResponeDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;
    private readonly IResourceService _resourceService;
    private readonly AppSettings _appSettings;
    public LoginAdminCommandHandler(IUnitOfWork unitOfWork,
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
    public async Task<TResponse<LoginResponeDto>> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        var hashedPassword = await _accountService.GetHashString(request.Password);
        var admin = await _unitOfWork.Users.GetUserAndHisRolesByEmail(request.Email);

        if (admin == default || admin.Password != hashedPassword)
            return TResponse<LoginResponeDto>.Failure(new[] { _resourceService.GetError("InvalidLogin") });
        else
        {
            
            return TResponse<LoginResponeDto>.Success(new LoginResponeDto
            {
                Token = _tokenService.GetAdminToken(admin),
                Id = admin.Id,
                Name = string.Concat(admin.FirstName, " ", admin.LastName),
                IsSuperAdmin = admin.IsSuperAdmin

            });
        }




    }
}
