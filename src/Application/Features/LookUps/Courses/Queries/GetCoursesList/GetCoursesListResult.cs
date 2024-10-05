using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesList;
public class GetCoursesListResult
{
    public List<CoursesItem> CoursesList { get; set; }
    public int TotalCount { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
}