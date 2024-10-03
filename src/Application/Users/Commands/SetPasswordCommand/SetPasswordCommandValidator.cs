using FluentValidation;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Application.Users.Commands.SetPasswordCommand;
public class SetPasswordCommandValidator : AbstractValidator<SetPaswordCommand>
{
    public SetPasswordCommandValidator(IResourceService resourceService)
    {



        RuleFor(_ => _.OTP)
                     .NotEmpty()
                     .WithMessage(resourceService.GetError("DecryptionKeyRequired"));

        RuleFor(_ => _.Pasword)
            .NotEmpty()
            .WithMessage(resourceService.GetError("PaswordRequired"));


        RuleFor(_ => _.Pasword)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=_|`~.><;*!])")
            .WithMessage(resourceService.GetError("InvalidPassword")).When(m => !string.IsNullOrEmpty(m.Pasword.Trim()))
            .MaximumLength(24)
            .WithMessage(resourceService.GetError("MaxLength24")).When(m => !string.IsNullOrEmpty(m.Pasword.Trim()))
            .MinimumLength(8)
            .WithMessage(resourceService.GetError("MinLength8")).When(m => !string.IsNullOrEmpty(m.Pasword.Trim()));

        RuleFor(_ => _.VerifyPassword)
         .NotEmpty()
         .WithMessage(resourceService.GetError("VerifyPaswordRequired"));

        RuleFor(_ => _.VerifyPassword)
           .Equal(_ => _.Pasword)
           .WithMessage(resourceService.GetError("Passworddoesnotmatch"))
           .When(m => !string.IsNullOrEmpty(m.Pasword.Trim()) &&
                      !string.IsNullOrEmpty(m.VerifyPassword.Trim()));




        //At least 1 captial letter    DONE
        //At least 1 small letter      DONE
        //Number                       DONE
        //Special characters           DONE
        //not more than 24             DONE
        //not less than 8              DONE
        //كلمه المرور غير متطابقه     Done
        //كلمه المرور غير صحيحه       DONE
        //كلمة المرور يجب أن تتكون من: حرف كبير على الأقل - حرف صغيرعلى الاقل - أرقام ورموز خاصة DONE


        //link expired after change password
        //Check that in case request a new password again, this link is expired and the new sent link in the email is the valid one 



    }
}
