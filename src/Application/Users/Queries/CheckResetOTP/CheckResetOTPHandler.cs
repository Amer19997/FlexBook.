using MediatR;
using FlexBook.Application.Common.Exceptions;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Models;

namespace FlexBook.Application.Users.Queries.CheckResetOTP;
public class CheckResetOTPHandler : IRequestHandler<CheckResetOTPQuery, TResponse<string>>
{
    public ICacheService _cacheService { get; set; }
    private readonly IResourceService _resourceService;


    public CheckResetOTPHandler(ICacheService cacheService, IResourceService resourceService)
    {
        _cacheService = cacheService;
        _resourceService = resourceService;
    }
    public async Task<TResponse<string>> Handle(CheckResetOTPQuery request, CancellationToken cancellationToken)
    {
        int.TryParse(_cacheService.GetAsync<string>(CachePrefix.LockForgetPassowrd, request.email, cancellationToken), out int lockCount);
        if (lockCount < 3)
        {
            var otp = _cacheService.GetAsync<OTPSettings>(CachePrefix.ForgetPassowrd, request.email, cancellationToken);
            if (string.IsNullOrEmpty(request.otp) || otp.OTPValue != request.otp)
            {
                 lockCount +=1;
                _cacheService.AddAsync(CachePrefix.LockForgetPassowrd, request.email, 2, lockCount.ToString());
                throw new BussinessValidationException(_resourceService.GetError("WrongOTP"));
            }
            else
            {
                _cacheService.Delete(CachePrefix.LockForgetPassowrd, request.email);
                return TResponse<string>.Success(_resourceService.GetInfo("NowYouCanRestPassword"));
            }
        }
        {
            return TResponse<string>.Failure(_resourceService.GetError("YouAreLocked"));
        }
    }
}
