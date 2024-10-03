using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Application.Users.Commands.ForgetPasswordAdminCommand;
public class ForgetPasswordAdminCommandValidator : AbstractValidator<ForgetPasswordAdminCommand>
{
    public ForgetPasswordAdminCommandValidator(IResourceService resourceService)
    {
        RuleFor(_ => _.Email)
          .NotNull()
          .NotEmpty()
          .WithMessage(resourceService.GetError("EmailIsRequired"))
          .EmailAddress()
          .WithMessage(resourceService.GetError("InvalidEmailFormat"))
          .MaximumLength(100)
          .WithMessage(resourceService.GetError("EmailLengthNotValid"));
    }

}
