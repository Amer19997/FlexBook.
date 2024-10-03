using FluentValidation;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Application.Users.Queries.CheckResetOTP;
public class CheckForgetPasswordOtpValidator:AbstractValidator<CheckResetOTPQuery>
{
    public CheckForgetPasswordOtpValidator(IResourceService resourceService)
    {
        RuleFor(_ => _.otp)
                    .NotEmpty()
                    .WithMessage(resourceService.GetError("DecryptionKeyRequired"));

        RuleFor(_ => _.email)
         .NotNull()
         .NotEmpty()
         .WithMessage(resourceService.GetError("EmailIsRequired"))
         .EmailAddress()
         .WithMessage(resourceService.GetError("InvalidEmailFormat"))
         .MaximumLength(100)
         .WithMessage(resourceService.GetError("EmailLengthNotValid"));
    }
}
