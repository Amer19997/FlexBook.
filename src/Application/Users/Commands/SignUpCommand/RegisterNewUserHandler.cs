using MediatR;
using Microsoft.Extensions.Options;
using FlexBook.Application.Common.Helpers;
using FlexBook.Application.Common.Interfaces;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Users.Commands.LoginAdminCommand;
using FlexBook.Domain;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Domain.Enums;
using static System.Net.WebRequestMethods;

namespace FlexBook.Application.Users.Commands.SignUpCommand;
public class RegisterNewUserHandler : IRequestHandler<RegisterNewUserCommand, TResponse<RegisterNewUserResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAccountService _accountService;
    private readonly ITokenService _tokenService;
    private readonly IResourceService _resourceService;
    private readonly AppSettings _appSettings;
    private readonly IMediator _mediator;

    public RegisterNewUserHandler(IUnitOfWork unitOfWork,
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
    public async Task<TResponse<RegisterNewUserResult>> Handle(RegisterNewUserCommand request, CancellationToken cancellationToken)
    {
        var admin = await _unitOfWork.Users.CheckEmailIsFound(request.Email);
        if (admin)
        {
            return TResponse<RegisterNewUserResult>.Failure(new[] { _resourceService.GetError("ThisEmailAlerdyFound") });
        }

        else
        {
            var universityId = !string.IsNullOrEmpty(request.UniversityName) ?
                               await _unitOfWork.UnivesityRepository.AddAsync(new University
                               {
                                   Id = Guid.NewGuid(),
                                   CountryId = request.CountryId,
                                   LookUpStatus = LookUpStatus.Pending,
                                   NameAr = request.UniversityName,
                                   NameEn = request.UniversityName
                               }) : request.UniversityId;


            var facultyId = !string.IsNullOrEmpty(request.FacultyName) ?
                               await _unitOfWork.FacultyRepository.AddAsync(new Faculty
                               {
                                   Id = Guid.NewGuid(),
                                   UniversityId = universityId ?? Guid.Empty,
                                   LookUpStatus = LookUpStatus.Pending,
                                   NameAr = request.FacultyName,
                                   NameEn = request.FacultyName
                               }) : request.FacultyId;


            var departmentId = !string.IsNullOrEmpty(request.DepartmentName) ?
                             await _unitOfWork.DepartmentRepository.AddAsync(new Department
                             {
                                 Id = Guid.NewGuid(),
                                 FacultyId = facultyId,
                                 LookUpStatus = LookUpStatus.Pending,
                                 NameAr = request.DepartmentName,
                                 NameEn = request.DepartmentName
                             }) : request.DepartmentId;

            var hashassword = await _accountService.GetHashString(request.Password);

            var user = User.Init(request.FirstName, request.LastName, request.MobileNumber, request.Email, request.CountryId, universityId, facultyId, departmentId, (UserTypeEnum)request.UserType, hashassword);
            var interstesList = request.InterstesListId.Select(item => new UserInterstes { CourseId = item, UserId = user.Id }).ToList();
            user.UserInterstesList = interstesList;
            await _unitOfWork.Users.Add(user, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            await _mediator.Publish(new AddNewUserEvent(request.Email, string.Concat(request.FirstName, " ", request.LastName), _appSettings.FileSettings.BaseApiUrl));


        }
        return TResponse<RegisterNewUserResult>.Success(new RegisterNewUserResult());
    }
}
