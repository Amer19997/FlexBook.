using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexBook.Domain.Entities.Catalog.Dtos;

namespace FlexBook.Application.Features.LookUps.Courses.Queries.GetCourses;

public class GetCoursesResult
{
    public List<CourseDto> Courseslist { get; set; }
    public int TotalCount { get; set; }
    public int pageNumber { get; set; }
    public int pageSize { get; set; }
}

