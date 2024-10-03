using MediatR;
using FlexBook.Application.Common.Exceptions;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Users.Queries.CheckOTPChangePassword;
public class CheckOTPChangePasswordHandler : IRequestHandler<CheckOTPChangePasswordCommand, TResponse<string>>
{
    public ICacheService _cacheService { get; set; }
    private readonly IResourceService _resourceService;

    public CheckOTPChangePasswordHandler(ICacheService cacheService, IResourceService resourceService)
    {
        _cacheService = cacheService;
        _resourceService = resourceService;
    }
    public async Task<TResponse<string>> Handle(CheckOTPChangePasswordCommand request, CancellationToken cancellationToken)
    {
        int.TryParse(  _cacheService.GetAsync<string>(CachePrefix.LockForgetPassowrd, request.Email, cancellationToken),out int lockCount);
        if (lockCount < 3)
        {
            string otp = _cacheService.GetAsync<string>(CachePrefix.ForgetPassowrd, request.Email, cancellationToken);
            if (!string.IsNullOrEmpty(request.OTP) || otp != request.OTP)
            {
                _cacheService.AddAsync(CachePrefix.LockForgetPassowrd, request.Email, 2, (lockCount++).ToString());
                throw new BussinessValidationException(_resourceService.GetError("WrongOTP"));
            }
            else
            {
                _cacheService.Delete(CachePrefix.LockForgetPassowrd, request.Email);
                return TResponse<string>.Success(_resourceService.GetInfo("NowYouCanRestPassword"));
            }
        }
        {
            return TResponse<string>.Success(_resourceService.GetInfo("YouAreLocked"));
        }
    }
}
