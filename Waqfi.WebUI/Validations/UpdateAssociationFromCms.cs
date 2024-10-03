using FluentValidation;
using Waqfi.Application.Common.Interfaces;
using WebUI.Client;

namespace WebUI.Validations;

public class UpdateAssociationFromCms:AbstractValidator<GetAssociationDetailsForCMSEditionResult>
{
    public UpdateAssociationFromCms(IResourceService resourceService)
    {
        RuleFor(_ => _.ContactInfo.Email)
        .NotEmpty()
          .WithMessage(resourceService.GetError("ThisFeildRequired"))
          .MaximumLength(200)
          .WithMessage(resourceService.GetError("MaxLength200"));
    }
}
