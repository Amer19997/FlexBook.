using System.Linq.Expressions;
using MediatR;
using FlexBook.Application.Common.Models;
using FlexBook.Domain;
using FlexBook.Domain.Entities.UsersAggregate;
using FlexBook.Domain.Enums;

namespace FlexBook.Application.Features.Admin.SignUpRequest.Queries.GetSignUpRequestList;

public class GetSignUpListHandler : IRequestHandler<GetSignUpListQuery, TResponse<GetSignUpListResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetSignUpListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse<GetSignUpListResult>> Handle(GetSignUpListQuery request, CancellationToken cancellationToken)
    {

        var filterQuery = filter();
        var resu = await _unitOfWork.Users.FindPagedList(filters: filterQuery,
                                                         orderBy: q => q.OrderByDescending(r => r.Created),
                                                         pageNumber: request.pageNumber,
                                                         pageSize: request.pageSize,
                                                         includeProperties: "Country,University,Department,Faculty");

        var total = await _unitOfWork.Users.CountAsync(filters: filterQuery);

        var userList = resu.Select(m => new UserItem
        {
            Id = m.Id,
            FirstName = m.FirstName,
            LastName = m.LastName,
            Email = m.Email,
            PhoneNumber = m.MobileNumber,
            CountryName = m.Country.NameAr,
            UniversityName = m.University.NameAr,
            DepartmentName = m.Department.NameAr,
            FacultyName = m.Faculty.NameAr,
            UserType = m.UserType
        }).ToList();

        return TResponse<GetSignUpListResult>.Success(new GetSignUpListResult
        {
            UserList = userList,
            pageNumber = request.pageNumber,
            pageSize = request.pageSize,
            TotalCount = total
        });
    }
    private IEnumerable<Expression<Func<User, bool>>> filter()
    {
        var filters = new List<Expression<Func<User, bool>>>
        {
            x => x.Status == UserStatus.Pending
        };



        return filters;
    }
}
public record GetSignUpListQuery(int pageNumber, int pageSize) : IRequest<TResponse<GetSignUpListResult>>;

public class GetSignUpListResult
{
    public List<UserItem> UserList { get; set; }
    public int TotalCount { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
}
public class UserItem
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public UserTypeEnum UserType { get; set; }
    public string CountryName { get; set; }
    public string UniversityName { get; set; }
    public string FacultyName { get; set; }
    public string DepartmentName { get; set; }

}

