using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Domain.Enums;
using FlexBook.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Helpers;
using Microsoft.Extensions.Options;

namespace FlexBook.Application.Features.Admin.Commnds.CreateStudent;
public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, TResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;
    private readonly IResourceService _resourceService;
    private readonly AppSettings _appSettings;
    private readonly IMediator _mediator;

    public CreateStudentHandler(IUnitOfWork unitOfWork,
         IAccountService accountService,
         ITokenService tokenService,
         IOptions<AppSettings> appSettings,
         IResourceService resourceService,
         IMediator mediator)
    {
        _unitOfWork = unitOfWork;
        _accountService = accountService;
        _tokenService = tokenService;
        _appSettings = appSettings.Value;
        _resourceService = resourceService;
        _mediator = mediator;
    }

    public async Task<TResponse<Guid>> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
            return TResponse<Guid>.Failure(new[] { _resourceService.GetError("Passwords do not match") });
        var hashassword = await _accountService.GetHashString(request.Password);

        var student = User.Init(
            firstName: request.FirstName,
            lastName: request.LastName,
            mobileNumber: request.MobileNumber,
            email: request.Email,
            countryId: request.CountryId,
            universityId: request.UniversityId,
            facultyId: request.FacultyId,
            departmentId: request.DepartmentId,
            userType: UserTypeEnum.Student,
            password: hashassword
        );

        // Set student-specific properties
        student.UpdateStudentAcademicInfo(request.AcademicYear, request.StudyLevel);

        await _unitOfWork.Users.Add(student, cancellationToken);

        await _unitOfWork.CommitAsync(cancellationToken);

        return TResponse<Guid>.Success(student.Id);
    }
}
