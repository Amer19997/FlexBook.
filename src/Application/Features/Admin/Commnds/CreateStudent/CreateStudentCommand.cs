using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using MediatR;

namespace FlexBook.Application.Features.Admin.Commnds.CreateStudent;
public class CreateStudentCommand : IRequest<TResponse<Guid>>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string MobileNumber { get; set; }
    public int CountryId { get; set; }
    public Guid UniversityId { get; set; }
    public Guid FacultyId { get; set; }
    public Guid DepartmentId { get; set; }
    public string AcademicYear { get; set; }
    public string StudyLevel { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
