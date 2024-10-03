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
public record GetCoursesListQuery(int pageNumber, int pageSize) : IRequest<TResponse<GetCoursesListResult>>;

public class GetCoursesListResult
{
    public List<CoursesItem> CoursesList { get; set; }
    public int TotalCount { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
}
public class CoursesItem
{
    public int Id { get; set; }
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string DescAr {  get; set; }
    public string DescEn { get; set; }
    public bool IsActive { get; set; }
}
public record GetCoursesBasicListQuery : IRequest<TResponse<GetCoursesBasicListResult>>;
public class GetCoursesBasicListResult
{
    public List<BasicCourseItem> CoursesList { get; set; }
}

public class BasicCourseItem
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string CoverPhoto { get; set; } // Assuming you have a cover photo field
}
public class GetCoursesBasicListHandler : IRequestHandler<GetCoursesBasicListQuery, TResponse<GetCoursesBasicListResult>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetCoursesBasicListHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<TResponse<GetCoursesBasicListResult>> Handle(GetCoursesBasicListQuery request, CancellationToken cancellationToken)
    {
        var result = await _unitOfWork.CouresRepository
                                      .FindAsync(null, 
                                                 orderBy: q => q.OrderBy(r => r.NameEn), 
                                                 includeProperties: ""); // No need for includes if only fetching simple properties

        var courseList = result.Select(m => new BasicCourseItem
        {
            NameAr = m.NameAr,
            NameEn = m.NameEn,
            CoverPhoto = m.CoverPhoto // Assuming the Course entity has a CoverPhoto field
        }).ToList();

        return TResponse<GetCoursesBasicListResult>.Success(new GetCoursesBasicListResult
        {
            CoursesList = courseList
        });
    }
}
