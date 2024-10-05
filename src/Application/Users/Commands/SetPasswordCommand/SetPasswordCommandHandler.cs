using System.Threading;
using MediatR;
using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Exceptions;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Models;
using FlexBook.Domain;

namespace FlexBook.Application.Users.Commands.SetPasswordCommand;
public class SetPasswordCommandHandler : IRequestHandler<SetPaswordCommand, TResponse<string>>
{
    public IUnitOfWork _unitOfWork { get; set; }
    public IAccountService _accountService { get; set; }
    public ICacheService _cacheService { get; set; }

    private readonly IResourceService _resourceService;

    private readonly AppSettings _appSettings;
    public SetPasswordCommandHandler(IUnitOfWork unitOfWork,
                                     IResourceService resourceService,
                                     IAccountService accountService,
                                     ICacheService cacheService,
                                     IOptions<AppSettings> appSettings)
    {
        _unitOfWork = unitOfWork;
        _resourceService = resourceService;
        _accountService = accountService;
        _cacheService = cacheService;
        _appSettings = appSettings.Value;
    }

    public async Task<TResponse<string>> Handle(SetPaswordCommand request, CancellationToken cancellationToken)
    {    
        var result =  _cacheService.GetAsync<OTPSettings>(CachePrefix.ForgetPassowrd, request.Email, cancellationToken);
        if (result == null || result.OTPValue != request.OTP)
            throw new BussinessValidationException(_resourceService.GetError("WrongOTP"));

        int.TryParse(_cacheService.GetAsync<string>(CachePrefix.LockForgetPassowrd, request.Email, cancellationToken), out int lockCount);
        if (lockCount >= 3)
            return TResponse<string>.Failure(new[] { _resourceService.GetError("YouAreLocked") });

        var updateResult = await UpdateUser(request, cancellationToken, request.Email);
        if(!updateResult)
            throw new BussinessValidationException(_resourceService.GetError("EmailNotFound"));

        _cacheService.Delete(CachePrefix.ForgetPassowrd, request.Email);
        return TResponse<string>.Success(_resourceService.GetInfo("PasswordRestSuccessfully"));

    }

    private async Task<bool> UpdateUser(SetPaswordCommand request, CancellationToken cancellationToken, string email)
    {
        var status = true;
        var user = await _unitOfWork.Users.GetActiveUserByEmail(email);

        if (user == null)
            return false;

        if (string.IsNullOrEmpty(user.Password))
            status = false;

        var hashPassword = await _accountService.GetHashString(request.Pasword);
        var newUser = user.UpdateUserPassword(hashPassword, status);
         _unitOfWork.Users.UpdateUser(newUser);
        await _unitOfWork.CommitAsync(cancellationToken);

        return true;
    }


}
