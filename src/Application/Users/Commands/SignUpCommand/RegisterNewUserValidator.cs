using System.Diagnostics;
using FluentValidation;
using FlexBook.Application.Common.Interfaces;

namespace FlexBook.Application.Users.Commands.SignUpCommand;
public class RegisterNewUserValidator : AbstractValidator<RegisterNewUserCommand>
{
    public bool universityFlag = true;
    public bool facultyFlag = true;
    public bool departmentFlag = true;
    public RegisterNewUserValidator(IResourceService resourceService)
    {

        RuleFor(_ => _.Email)
            .NotNull()
            .NotEmpty()
            .WithMessage(resourceService.GetError("PleaseEnterEmail"))
            .EmailAddress()
            .WithMessage(resourceService.GetError("PleaseEnterEmail"))
            .MaximumLength(100)
            .WithMessage(resourceService.GetError("PleaseEnterEmail"));

        RuleFor(_ => _.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage(resourceService.GetError("PleaseEnterFirstName"))
            .MaximumLength(50)
            .WithMessage(resourceService.GetError("PleaseEnterFirstName"))
            .MinimumLength(2)
            .WithMessage(resourceService.GetError("PleaseEnterFirstName"));

        RuleFor(_ => _.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage(resourceService.GetError("PleaseEnterLastName"))
            .MaximumLength(100)
            .WithMessage(resourceService.GetError("PleaseEnterLastName"))
            .MinimumLength(2)
            .WithMessage(resourceService.GetError("PleaseEnterLastName"));


        RuleFor(_ => _.Password)
            .NotEmpty()
            .WithMessage(resourceService.GetError("PaswordRequired"));


        RuleFor(_ => _.Password)
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%^&+=_|`~.><;*!])")
            .WithMessage(resourceService.GetError("InvalidPassword")).When(m => !string.IsNullOrEmpty(m.Password.Trim()))
            .MaximumLength(20)
            .WithMessage(resourceService.GetError("InvalidPassword")).When(m => !string.IsNullOrEmpty(m.Password.Trim()))
            .MinimumLength(8)
            .WithMessage(resourceService.GetError("InvalidPassword")).When(m => !string.IsNullOrEmpty(m.Password.Trim()))
            .When(m => !string.IsNullOrEmpty(m.Password));


       
        RuleFor(_ => _.VerifayPassword)
           .Equal(_ => _.Password)
           .WithMessage(resourceService.GetError("Passworddoesnotmatch"))
           .When(m => !string.IsNullOrEmpty(m.Password.Trim()) &&
                      !string.IsNullOrEmpty(m.VerifayPassword.Trim()));

        //===============================================================================
        // step 2

        RuleFor(_ => _.MobileNumber)
          .NotNull()
          .NotEmpty()
          .WithMessage(resourceService.GetError("MobileRequired"))
          .MaximumLength(15)
          .WithMessage(resourceService.GetError("MobileNumberLengthNotValid"))
          .MinimumLength(10)
          .WithMessage(resourceService.GetError("MobileNumberLengthNotValid"));



        RuleFor(_ => _.CountryId)
            .NotEmpty()
            .WithMessage(resourceService.GetError("CountryRequired"));

        RuleFor(_ => _.UniversityId)
            .NotEmpty()
            .When(m => string.IsNullOrEmpty(m.UniversityName))
            .WithMessage(resourceService.GetError("UniversityRequired"));

        RuleFor(_ => _.FacultyId)
            .NotEmpty()
            .When(m => string.IsNullOrEmpty(m.FacultyName))
            .WithMessage(resourceService.GetError("facultyRequired"));

        RuleFor(_ => _.DepartmentId)
            .NotEmpty()
            .When(m => string.IsNullOrEmpty(m.DepartmentName))
            .WithMessage(resourceService.GetError("DepartmentRequired"));

        //=============================================================================

        RuleFor(_ => _.UniversityName)
           .NotEmpty()
           .When(m => m.UniversityId == default)
           .WithMessage("يجب كتابة اسم الجامعه");

        RuleFor(_ => _.FacultyName)
            .NotEmpty()
            .When(m => m.FacultyId == default)
            .WithMessage("يجب كتابة اسم الكلية");

        RuleFor(_ => _.DepartmentName)
            .NotEmpty()
            .When(m => m.DepartmentId == default)
            .WithMessage("يجب كتابة اسم القسم");

        //=======================================================================

        RuleFor(_ => _.Note)
           .MaximumLength(250)
           .WithMessage(resourceService.GetError("NoteLength"));


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
