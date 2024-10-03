using System.Linq.Expressions;
using MediatR;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.LookUps.Univesity.Queries.GetUnivesityList;
using FlexBook.Domain;
using FlexBook.Domain.Entities.LookUps;
using X.PagedList;

namespace FlexBook.Application.Features.LookUps.Department.Queries.GetDepartmentList;
public class GetDepartmentListHandler : IRequestHandler<GetDepartmentListQuery, TResponse<GetDepartmentListResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetDepartmentListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse<GetDepartmentListResult>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
    {
        var resu = await _unitOfWork.DepartmentRepository.FindPagedList(filters: filter(request.facultyId),
                                                               includeProperties: "Faculty");

        var DepartmentList = resu.Select(m => new DepartmentItem
        {
            Id = m.Id,
            NameAr = m.NameAr,
            NameEn = m.NameEn,
            FacultyId=m.FacultyId ?? Guid.Empty,
            FacultyName=m.Faculty?.NameAr,
            IsActive = m.IsActive
        }).ToList();

        return TResponse<GetDepartmentListResult>.Success(new GetDepartmentListResult
        {
            DepartmentList = DepartmentList,
        });


    }

    private IEnumerable<Expression<Func<Domain.Entities.LookUps.Department, bool>>> filter(Guid facultyId)
    {
        var filters = new List<Expression<Func<Domain.Entities.LookUps.Department, bool>>>
        {
            x => x.FacultyId == facultyId &&
                 x.LookUpStatus== Domain.Enums.LookUpStatus.Active
        };

        return filters;
    }
}
