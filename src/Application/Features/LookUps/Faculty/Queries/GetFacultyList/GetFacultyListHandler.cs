using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.LookUps.Department.Queries.GetDepartmentList;
using FlexBook.Domain;
using FlexBook.Domain.Entities.LookUps;
using FlexBook.Domain.Entities.UsersAggregate;

namespace FlexBook.Application.Features.LookUps.Faculty.Queries.GetFacultyList;
public record GetFacultyListQuery(Guid universtyId) :IRequest<TResponse<GetFacultyListResult>>;

public class GetFacultyListHandler : IRequestHandler<GetFacultyListQuery, TResponse<GetFacultyListResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetFacultyListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse<GetFacultyListResult>> Handle(GetFacultyListQuery request, CancellationToken cancellationToken)
    {
        var resu = await _unitOfWork.FacultyRepository.FindPagedList(filters: filter(request.universtyId),
                                                               orderBy: q => q.OrderByDescending(r => r.Id),
                                                               includeProperties: "University");

        var facultyList = resu.Select(m => new FacultyItem
        {
            Id = m.Id,
            NameAr = m.NameAr,
            NameEn = m.NameEn,
            UniversityId = m.UniversityId,
            UniversityName = m.University.NameAr,
            IsActive = m.IsActive
        }).ToList();

        return TResponse<GetFacultyListResult>.Success(new GetFacultyListResult
        {
            FacultyList = facultyList
        });
    }
    private IEnumerable<Expression<Func<Domain.Entities.LookUps.Faculty, bool>>> filter(Guid universtyId)
    {
        var filters = new List<Expression<Func<Domain.Entities.LookUps.Faculty, bool>>>
        {
            x => x.UniversityId == universtyId &&
                 x.LookUpStatus== Domain.Enums.LookUpStatus.Active
        };

        return filters;
    }
}

public class GetFacultyListResult
{
    public List<FacultyItem> FacultyList { get; set; }
   
}
public class FacultyItem
{
    public Guid Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public Guid UniversityId {  get; set; }
    public string UniversityName {  get; set; }
    public bool IsActive {  get; set; }
}