using MediatR;
using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Exceptions;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Users.Commands.LoginAdminCommand;
using FlexBook.Domain;
using static System.Net.WebRequestMethods;

namespace FlexBook.Application.Users.Commands.ForgetPasswordAdminCommand;
public class ForgetPasswordAdminCommandHandler : IRequestHandler<ForgetPasswordAdminCommand, TResponse<ForgetPasswordAdminCommandResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICacheService _cacheService;
    private readonly IResourceService _resourceService;
    private readonly IMediator _mediator;
    private readonly AppSettings _appSettings;

    public ForgetPasswordAdminCommandHandler(IUnitOfWork unitOfWork,
        ICacheService cacheService,
        IResourceService resourceService,
        IOptions<AppSettings> appSettings, IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _cacheService = cacheService;
        _resourceService = resourceService;
        _appSettings = appSettings.Value;
        _mediator = mediator;
    }
    public async Task<TResponse<ForgetPasswordAdminCommandResult>> Handle(ForgetPasswordAdminCommand request, CancellationToken cancellationToken)
    {
        var admin = await _unitOfWork.Users.GetActiveUserByEmail(request.Email);
        if (admin == default)
            throw new BussinessValidationException(_resourceService.GetError("EmailNotFound"));

        var otpValue = _cacheService.GetAsync<OTPSettings>(CachePrefix.ForgetPassowrd, request.Email, cancellationToken);
        if (otpValue != default)
        {
            throw new BussinessValidationException(string.Format(_resourceService.GetError("PleaseTryAfter{0}"), "2"));
        }

        otpValue =new OTPSettings();
        var otp = (new Random().Next(1000, 10000)).ToString();
        otpValue.OTPValue = otp;

        _cacheService.Delete(CachePrefix.LockForgetPassowrd, request.Email);
        _cacheService.AddAsync(CachePrefix.ForgetPassowrd, request.Email, 2, otpValue);
        await _mediator.Publish(new ForgetPasswordEvent(request.Email, string.Concat(admin.FirstName," ", admin.LastName), _appSettings.FileSettings.BaseApiUrl, otp));

        return TResponse<ForgetPasswordAdminCommandResult>.Success(new ForgetPasswordAdminCommandResult { Message = "تم إرسال تعليمات استعادة كلمة المرور إلى بريدك الإلكتروني" });
    }

}
