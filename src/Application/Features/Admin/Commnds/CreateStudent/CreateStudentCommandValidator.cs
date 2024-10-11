using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FlexBook.Application.Features.Admin.Commnds.CreateStudent;
 
public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
{
    public CreateStudentCommandValidator()
    {
        // Name validation
        RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name is required.")
            .MaximumLength(50).WithMessage("First name must not exceed 50 characters.");

        RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required.")
            .MaximumLength(50).WithMessage("Last name must not exceed 50 characters.");

        // Email validation
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        // Mobile number validation
        RuleFor(x => x.MobileNumber)
            .NotEmpty().WithMessage("Mobile number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("Invalid mobile number format.");

        // Country ID validation
        RuleFor(x => x.CountryId)
            .NotEmpty().WithMessage("Country is required.");

        // University, Faculty, and Department IDs validation
        RuleFor(x => x.UniversityId)
            .NotEmpty().WithMessage("University is required.");

        RuleFor(x => x.FacultyId)
            .NotEmpty().WithMessage("Faculty is required.");

        RuleFor(x => x.DepartmentId)
            .NotEmpty().WithMessage("Department is required.");

        // Academic Year validation
        RuleFor(x => x.AcademicYear)
            .NotEmpty().WithMessage("Academic year is required.")
            .Matches(@"^\d{4}-\d{4}$").WithMessage("Academic year must be in 'YYYY-YYYY' format.");

        // Study Level validation
        RuleFor(x => x.StudyLevel)
            .NotEmpty().WithMessage("Study level is required.");

        // Password validation with pattern
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$")
            .WithMessage("Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.");

        RuleFor(x => x.ConfirmPassword)
            .Equal(x => x.Password).WithMessage("Password confirmation does not match the password.");
    }
}