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
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using Microsoft.Extensions.Options;
using FlexBook.Application.Users.Commands.SignUpCommand;

namespace FlexBook.Application.Features.Admin.Commnds.CreateInstructor;
public class CreateInstructorHandler : IRequestHandler<CreateInstructorCommand, TResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;
    private readonly IResourceService _resourceService;
    private readonly AppSettings _appSettings;
    private readonly IMediator _mediator;

    public CreateInstructorHandler(IUnitOfWork unitOfWork,
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

    public async Task<TResponse<Guid>> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
    {
        // Check if the passwords match
        if (request.Password != request.ConfirmPassword)
            return TResponse<Guid>.Failure(new[] { _resourceService.GetError("Passwords do not match") });

        // Hash the password
        var hashassword = await _accountService.GetHashString(request.Password);

        // Initialize the new instructor using the User class with UserTypeEnum.Instructor
        var instructor = User.Init(
            firstName: request.FirstName,
            lastName: request.LastName,
            mobileNumber: request.MobileNumber,
            email: request.Email,
            countryId: request.CountryId,
            universityId: request.UniversityId,
            facultyId: request.FacultyId,
            departmentId: request.DepartmentId,
            userType: UserTypeEnum.Instructor,
            password: hashassword
        );

        // Update instructor-specific properties
        instructor.UpdateInstructorSpecialization(request.SpecializationId);

        // Save the new instructor to the database
        await _unitOfWork.Users.Add(instructor, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);

        // Return the instructor's ID as the response
        return TResponse<Guid>.Success(instructor.Id, _resourceService.GetMessage("Instructor created successfully"));
 
    }
}
