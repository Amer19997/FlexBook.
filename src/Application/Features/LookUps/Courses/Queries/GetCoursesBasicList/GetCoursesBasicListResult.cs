using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesList;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCoursesBasicListQuery;
public class GetCoursesBasicListResult
{
    public List<BasicCourseItem> CoursesList { get; set; }
}
