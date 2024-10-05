using MediatR;
using FlexBook.Application.Common.Models;
using FlexBook.Domain;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesList;
public class GetCoursesListHandler : IRequestHandler<GetCoursesListQuery, TResponse<GetCoursesListResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetCoursesListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<TResponse<GetCoursesListResult>> Handle(GetCoursesListQuery request, CancellationToken cancellationToken)
    {
        var resu = await _unitOfWork.CouresRepository.FindPagedList(filters: null,
                                                              orderBy: q => q.OrderByDescending(r => r.Id),
                                                              pageNumber: request.pageNumber,
                                                              pageSize: request.pageSize);

        var total = await _unitOfWork.CouresRepository.CountAsync(filters: null);

        var couresList = resu.Select(m => new CoursesItem
        {
            Id = m.Id,
            NameAr = m.NameAr,
            NameEn = m.NameEn,
            CoverPhoto = m.CoverPhoto,
            IsActive = m.IsActive
        }).ToList();

        return TResponse<GetCoursesListResult>.Success(new GetCoursesListResult
        {
            CoursesList = couresList,
            pageNumber = request.pageNumber,
            pageSize = request.pageSize,
            TotalCount = total
        });
    }
}


public class CoursesItem
{
    public Guid Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string DescAr {  get; set; }
    public string DescEn { get; set; }
    public bool IsActive { get; set; }
    public string CoverPhoto { get; set; } // Added CoverPhoto property

}


