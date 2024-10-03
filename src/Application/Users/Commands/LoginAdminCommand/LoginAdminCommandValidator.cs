using FluentValidation;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Application.Users.Commands.LoginAdminCommand;
public class LoginAdminCommandValidator : AbstractValidator<LoginAdminCommand>
{
    public LoginAdminCommandValidator(IResourceService resourceService)
    {
        RuleFor(_ => _.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage(resourceService.GetError("EmailIsRequired"))
            .EmailAddress()
            .WithMessage(resourceService.GetError("InvalidEmail"))
            .MaximumLength(255)
            .WithMessage(resourceService.GetError("EmailLengthNotValid"));

        RuleFor(_ => _.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage(resourceService.GetError("PasswordRequired"));

        RuleFor(_ => _.Password)
           .Matches("^(?=.*[a-" +
           "z])(?=.*[A-Z])(?=.*[@#$%^&+=_|`~.><;*!])")
           .WithMessage(resourceService.GetError("InvalidPassword")).When(m => !string.IsNullOrEmpty(m.Password.Trim()))
           .MaximumLength(20)
           .WithMessage(resourceService.GetError("MaxLength20")).When(m => !string.IsNullOrEmpty(m.Password.Trim()))
           .MinimumLength(8)
           .WithMessage(resourceService.GetError("MinLength8")).When(m => !string.IsNullOrEmpty(m.Password.Trim()));

    }
}
