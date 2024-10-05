using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Common.Models;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesList;
using FlexBook.Domain;
using MediatR;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesBasicListQuery;
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
public class BasicCourseItem
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public string CoverPhoto { get; set; } // Assuming you have a cover photo field
}
